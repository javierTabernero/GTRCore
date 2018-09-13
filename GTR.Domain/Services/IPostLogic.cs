using GTR.Domain.Model.Data;
using GTR.Domain.Services.Base;
using System.Collections.Generic;

namespace GTR.Domain.Services
{
    public interface IPostLogic : IBaseServiceCrudLogic<Post, int>
    {
        List<Post> GetByBlogId(int blogId, User user);

        Post GetById(int Id, User user);
    }
}