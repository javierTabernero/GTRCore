using GTR.Domain.Model.Data;
using GTR.Service.Services.Base;
using System.Collections.Generic;

namespace GTR.Service.Services
{
    public interface IPostService : IBaseServiceCrud<Post, int>
    {
        List<Post> GetByBlogId(int blogId, User user);

        Post GetById(int Id, User user);
    }
}