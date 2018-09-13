using GTR.Domain.Model.Data;
using GTR.Service.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Service.Services
{
    public interface IPostService : IBaseServiceCrud<Post, int>
    {
        List<Post> GetByBlogId(int blogId, User user);

        Task<List<Post>> GetByBlogIdAsync(int blogId, User user);

        Post GetById(int Id, User user);

        Task<Post> GetByIdAsync(int Id, User user);
    }
}