using System.Collections.Generic;
using System.Threading.Tasks;
using Post = Website.Shared.Post;

namespace Website.Client.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAll();

        Task<Post> Get(string id);
    }
    
}