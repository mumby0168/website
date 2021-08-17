using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Website.Functions.Abstractions;
using Website.Shared;

namespace Website.Functions.Api
{
    public class TagsApi : BaseFunction
    {
        private readonly IRepository<TechTag> _tagsRepository;

        public TagsApi(IRepository<TechTag> tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }
        
        [FunctionName("get-all-tags")]
        public async Task<IActionResult> GetBlogPosts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "tag")]
            HttpRequestMessage request,
            ILogger log
        )
        {
            var tags = await _tagsRepository.GetAsync(p => p.Type == nameof(TechTag));

            return Ok(tags);
        }
    }
}