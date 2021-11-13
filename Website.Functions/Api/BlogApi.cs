using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Website.Functions.Abstractions;
using Website.Shared;

namespace Website.Functions.Api
{
    public class BlogApi : BaseFunction
    {
        private readonly IRepository<Post> _postRepository;

        public BlogApi(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        [FunctionName("published-post")]
        public async Task<IActionResult> GetPublished(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "blog/{id}")]
            HttpRequestMessage request,
            string id,
            ILogger log
        )
        {
            try
            {
                var post = await _postRepository.GetAsync(id, nameof(Post));
                
                if(post.IsPublished is false)
                {
                    return NotFound();
                }

                log.LogInformation($"Post with id: {id} found.");
                return Ok(post);
            }
            catch (CosmosException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                log.LogWarning($"No post found with id: {id}.");
                return NotFound();
            }
        }

        


        [FunctionName("all-published-posts")]
        public async Task<IActionResult> GetAllPublished(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "blog")]
            HttpRequestMessage request,
            ILogger log
        )
        {
            var post = (await _postRepository.GetAsync(p => p.Type == nameof(Post) && p.IsPublished)).ToList();
            log.LogInformation($"{post.Count()} published posts found");

            return Ok(post);
        }
        
    }
}