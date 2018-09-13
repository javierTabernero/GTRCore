using GTR.Domain.Model.Data;
using GTR.Domain.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Domain.Services
{
    public interface IPostLogic : IBaseServiceCrudLogic<Post, int>
    {
        List<Post> GetByBlogId(int blogId, User user);

        Task<List<Post>> GetByBlogIdAsync(int blogId, User user);

        Post GetById(int Id, User user);

        Task<Post> GetByIdAsync(int Id, User user);
    }
}