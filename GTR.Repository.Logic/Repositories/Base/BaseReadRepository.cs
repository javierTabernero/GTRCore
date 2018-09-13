using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTR.Repository.Logic.Repositories.Base
{
    public class BaseReadRepository<TUnitOfWork, TEntity, TEntityKey> : BaseRepository<TUnitOfWork, TEntity>
        where TUnitOfWork : DbContext
        where TEntity : class
    {
        public BaseReadRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public virtual TEntity GetById(TEntityKey entityId)
        {
            TEntity repositoryEntity = Context.Set<TEntity>().Find(entityId);

            if (repositoryEntity == null)
            {
                throw new KeyNotFoundException();
            }

            return repositoryEntity;
        }

        public async virtual Task<TEntity> GetByIdAsync(TEntityKey entityId)
        {
            TEntity repositoryEntity = await Context.Set<TEntity>().FindAsync(entityId);

            if (repositoryEntity == null)
            {
                throw new KeyNotFoundException();
            }

            return repositoryEntity;
        }

        public bool ExistsId(TEntityKey id)
        {
            bool exists = false;
            try
            {
                TEntity repositoryEntity = GetById(id);

                if (repositoryEntity != null)
                {
                    exists = true;
                }
            }
            catch (KeyNotFoundException)
            {
                exists = false;
            }

            return exists;
        }

        public async Task<bool> ExistsIdAsync(TEntityKey id)
        {
            bool exists = false;
            try
            {
                TEntity repositoryEntity = await GetByIdAsync(id);

                if (repositoryEntity != null)
                {
                    exists = true;
                }
            }
            catch (KeyNotFoundException)
            {
                exists = false;
            }

            return exists;
        }
    }
}