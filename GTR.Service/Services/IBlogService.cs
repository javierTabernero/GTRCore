using GTR.Domain.Model.Data;
using GTR.Service.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Service.Services
{
    public interface IBlogService : IBaseServiceCrud<Blog, int>
    {
        Blog GetById(int id, User user);
        
        Task<Blog> GetByIdAsync(int id, User user);

        List<Blog> GetAll();

        Task<List<Blog>> GetAllAsync();
    }
}