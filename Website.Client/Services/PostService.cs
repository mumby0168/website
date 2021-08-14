using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Shared;
using Post = Website.Shared.Post;

namespace Website.Client.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts = new()
        {
            new Post()
            {
                Id = "microsoft-di-getting-started",
                Title = "Getting Started with Microsoft.Extensions.DependencyInjection",
                GistUrl = "https://gist.github.com/mumby0168/8ef8a2849823b90a6abb25a740ab0aa9",
                GistFile = "microsoft-di.md",
                Description = @"Get started with Microsoft.Extensions.DependencyInjection package in a simple console application and see how larger frameworks such as 
                                aspnet core utilise this package.",
                Tags = new()
                {
                    new("nuget", Color.Info),
                    new("microsoft", Color.Primary),
                    new("csharp", Color.Info),
                    new("di", Color.Success),
                },
                RenderedHeightInPixels = 1750,
                CreatedUtc = new DateTime(2021, 8, 12, 15, 30, 0)
            },
        };
        
        public async Task<List<Post>> GetAll()
        {
            await Task.CompletedTask;
            return _posts;
        }

        public async Task<Post> Get(string id)
        {
            await Task.CompletedTask;
            return _posts.FirstOrDefault(p => p.Id == id);
        }
    }
}