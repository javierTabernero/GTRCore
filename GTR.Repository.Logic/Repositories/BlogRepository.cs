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
    public class BlogRepository : BaseRepositoryCrud<Blog, int>, IBlogRepository
    {
        public BlogRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Blog GetById(int id, User user)
        {
            return GetDbSet().Where(x => x.BlogId == id).FirstOrDefault();
        }

        public async Task<Blog> GetByIdAsync(int id, User user)
        {
            return await GetDbSet().Where(x => x.BlogId == id).FirstOrDefaultAsync();
        }

        protected override Blog GetEntityFromRepositoryToUpdate(Blog entityToUpdate)
        {
            Blog blog = GetDbSet().Where(x => x.BlogId == entityToUpdate.BlogId).FirstOrDefault();

            if (blog == null)
            {
                throw new KeyNotFoundException();
            }

            return blog;
        }

        protected async override Task<Blog> GetEntityFromRepositoryToUpdateAsync(Blog entityToUpdate)
        {
            Blog blog = await GetDbSet().Where(x => x.BlogId == entityToUpdate.BlogId).FirstOrDefaultAsync();

            if (blog == null)
            {
                throw new KeyNotFoundException();
            }

            return blog;
        }

        private IQueryable<Blog> GetBaseDbSet()
        {
            Blog blog = new Blog();

            return GetDbSet()
                .Include(nameof(blog.Post));
        }
    }
}