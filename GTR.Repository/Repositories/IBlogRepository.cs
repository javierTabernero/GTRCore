using GTR.Repository.Model.Data.Users;
using GTR.Repository.Repositories.Base;
using System.Threading.Tasks;

namespace GTR.Repository.Repositories
{
    public interface IBlogRepository : IBaseRepositoryCrud<Model.Blog, int>
    {
        Model.Blog GetById(int id, User user);

        Task<Model.Blog> GetByIdAsync(int id, User user);
    }
}