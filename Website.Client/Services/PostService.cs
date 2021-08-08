using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Client.Pages;
using Post = Website.Shared.Post;

namespace Website.Client.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts = new()
        {
            new Post()
            {
                Id = "1",
                Title = "Post 1",
                GistUrl = "https://gist.github.com/Albert-W/e37d1c4fa30c430c37d7b1b1fe9b60d8",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam malesuada quis tellus ut laoreet. Pellentesque facilisis dolor id bibendum pretium. In magna lectus, accumsan in leo id, pulvinar tristique neque. Suspendisse mattis dui in volutpat elementum. Proin dapibus placerat felis, at volutpat quam interdum egestas. Sed elementum ornare ante. Integer eget orci diam. Donec vitae lorem vel lorem fringilla luctus. Mauris vel varius est. Proin lacinia tempus mi, quis pharetra neque euismod et.",
                CreatedUtc = DateTime.Now.AddDays(-20).ToUniversalTime()
            },
            new Post()
            {
                Id = "2",
                Title = "Post 2",
                GistUrl = "https://gist.github.com/mumby0168/22aa19681fdcf0066854a17349e730a3",
                GistFile = "test01.md",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam malesuada quis tellus ut laoreet. Pellentesque facilisis dolor id bibendum pretium. In magna lectus, accumsan in leo id, pulvinar tristique neque. Suspendisse mattis dui in volutpat elementum. Proin dapibus placerat felis, at volutpat quam interdum egestas. Sed elementum ornare ante. Integer eget orci diam. Donec vitae lorem vel lorem fringilla luctus. Mauris vel varius est. Proin lacinia tempus mi, quis pharetra neque euismod et.",
                CreatedUtc = DateTime.Now.ToUniversalTime()
            }
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