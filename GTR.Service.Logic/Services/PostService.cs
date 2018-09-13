using GTR.Domain.Model.Data;
using GTR.Domain.Services;
using GTR.Service.Logic.Services.Base;
using GTR.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Service.Logic.Services
{
    public class PostService : BaseServiceCrudLogic<Post, int>, IPostService
    {
        private readonly IPostLogic _postLogic;

        public PostService(IPostLogic postLogic) : base(postLogic)
        {
            _postLogic = postLogic;
        }

        public List<Post> GetByBlogId(int blogId, User user)
        {
            return _postLogic.GetByBlogId(blogId, user);
        }

        public async Task<List<Post>> GetByBlogIdAsync(int blogId, User user)
        {
            return await _postLogic.GetByBlogIdAsync(blogId, user);
        }

        public Post GetById(int id, User user)
        {
            return _postLogic.GetById(id, user);
        }

        public async Task<Post> GetByIdAsync(int id, User user)
        {
            return await _postLogic.GetByIdAsync(id, user);
        }
    }
}