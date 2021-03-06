using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Octokit;
using Website.Functions.Abstractions;
using Website.Shared;

namespace Website.Functions.Api
{
    public class OwnerBlogApi : BaseFunction
    {
        private readonly IRepository<Post> _postRepository;
        private readonly GitHubClient _gitHubClient;
        private readonly IRepository<TechTag> _techTagsRepository;

        public OwnerBlogApi(IRepository<Post> postRepository, GitHubClient gitHubClient, IRepository<TechTag> techTagsRepository)
        {
            _postRepository = postRepository;
            _gitHubClient = gitHubClient;
            _techTagsRepository = techTagsRepository;
        }

        [FunctionName("owner-get-post")]
        public async Task<IActionResult> GetPost(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "owner/blog/{id}")]
            HttpRequestMessage request,
            string id,
            ILogger log
        )
        {
            try
            {
                var post = await _postRepository.GetAsync(id, nameof(Post));

                log.LogInformation($"Post with id: {id} found.");
                return Ok(post);
            }
            catch (CosmosException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                log.LogWarning($"No post found with id: {id}.");
                return NotFound();
            }
        }
        
        [FunctionName("owner-get-all-posts")]
        public async Task<IActionResult> GetBlogPosts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "owner/blog")]
            HttpRequestMessage request,
            ILogger log
        )
        {
            var post = (await _postRepository.GetAsync(p => p.Type == nameof(Post))).ToList();
            log.LogInformation($"{post.Count()} un-published posts found");

            return Ok(post);
        }

        [FunctionName("owner-save-post")]
        public async Task<IActionResult> SavePost(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "owner/blog")]
            HttpRequestMessage request,
            ILogger log
        )
        {
            var post = await request.Content.ReadAsAsync<Post>();

            if (string.IsNullOrWhiteSpace(post.Id))
                return BadRequest("A post must have a unique id.");

            if (string.IsNullOrWhiteSpace(post.Title))
                return BadRequest("A post must have a title.");

            if (string.IsNullOrWhiteSpace(post.Description))
                return BadRequest("A post must have a description");
            
            if (string.IsNullOrWhiteSpace(post.GistUrl))
                return BadRequest("A gist url must be provided");

            if (post.Tags.Any(t => string.IsNullOrWhiteSpace(t.Id)))
                return BadRequest("All tech tags must have an id provided");
            
            //TODO: add an exists check for the id used. Wait on PR to be merged and released

            var uri = new Uri(post.GistUrl);
            var gistId = uri.Segments[^1];

            Gist gist;

            try
            {
                gist = await _gitHubClient.Gist.Get(gistId);
            }
            catch (ApiException e)
            {
                return BadRequest(e.ApiError.Message);
            }

            if (string.IsNullOrWhiteSpace(post.GistFile) is false && gist.Files.ContainsKey(post.GistFile) is false)
                return BadRequest($"The gist with id {post.Id} does not contain a file named {post.GistFile}");

            foreach (var postTag in post.Tags)
                await _techTagsRepository.UpdateAsync(postTag);

            await _postRepository.UpdateAsync(post);

            return Ok();
        }
    }
}