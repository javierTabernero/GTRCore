using GTR.Repository.Logic.Repositories.Base;
using GTR.Repository.Model;
using GTR.Repository.Model.Data.Users;
using GTR.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTR.Repository.Logic.Repositories
{
    public class PostRepository : BaseRepositoryCrud<Post, int>, IPostRepository
    {
        public PostRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public List<Post> GetByBlogId(int blogId, User user)
        {
            return GetDbSet().Where(x => x.BlogId == blogId).ToList();
        }

        public async Task<List<Post>> GetByBlogIdAsync(int blogId, User user)
        {
            return await GetDbSet().Where(x => x.BlogId == blogId).ToListAsync().ConfigureAwait(false);
        }

        public Post GetById(int id, User user)
        {
            return GetBaseDbSet().Where(x => x.PostId == id).FirstOrDefault();
        }

        public async Task<Post> GetByIdAsync(int id, User user)
        {
            return await GetBaseDbSet().Where(x => x.PostId == id).FirstOrDefaultAsync();
        }

        protected override Post GetEntityFromRepositoryToUpdate(Post entityToUpdate)
        {
            Post post = GetDbSet().Where(x => x.PostId == entityToUpdate.PostId).FirstOrDefault();

            if (post == null)
            {
                throw new KeyNotFoundException();
            }

            return post;
        }

        protected async override Task<Post> GetEntityFromRepositoryToUpdateAsync(Post entityToUpdate)
        {
            Post post = await GetDbSet().Where(x => x.PostId == entityToUpdate.PostId).FirstOrDefaultAsync();

            if (post == null)
            {
                throw new KeyNotFoundException();
            }

            return post;
        }

        private IQueryable<Post> GetBaseDbSet()
        {
            Post blog = new Post();

            return GetDbSet()
                .Include(nameof(blog.Blog));
        }
    }
}