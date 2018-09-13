using GTR.Repository.Model.Data.Users;
using GTR.Repository.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Repository.Repositories
{
    public interface IPostRepository : IBaseRepositoryCrud<Model.Post, int>
    {
        List<Model.Post> GetByBlogId(int blogId, User user);

        Task<List<Model.Post>> GetByBlogIdAsync(int blogId, User user);

        Model.Post GetById(int id, User user);

        Task<Model.Post> GetByIdAsync(int id, User user);
    }
}