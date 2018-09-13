using GTR.Domain.Model.Data;
using GTR.Domain.Services.Base;
using System.Collections.Generic;

namespace GTR.Domain.Services
{
    public interface IBlogLogic : IBaseServiceCrudLogic<Blog, int>
    {
        Blog GetById(int id, User user);
        List<Blog> GetAll();
    }
}