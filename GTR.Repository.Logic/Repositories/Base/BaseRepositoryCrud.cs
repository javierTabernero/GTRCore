using GTR.Repository.Logic.Model;
using GTR.Repository.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTR.Repository.Logic.Repositories.Base
{
    public class BaseRepositoryCrud<TEntity, TEntitykey> : BaseReadRepository<GtrEntities, TEntity, TEntitykey>, IBaseRepositoryCrud<TEntity, TEntitykey>
        where TEntity : class
    {
        public BaseRepositoryCrud(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public TEntity Add(TEntity entity)
        {
            GetDbSet().Add(entity);
            Context.Entry(entity).State = EntityState.Added;
            Save();

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await GetDbSet().AddAsync(entity).ConfigureAwait(false);
            Context.Entry(entity).State = EntityState.Added;
            await SaveAsync();

            return entity;
        }

        public void Delete(TEntity entity)
        {
            GetDbSet().Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Save();
        }

        private void Remove(TEntity entity)
        {
            GetDbSet().Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => Remove(entity)).ConfigureAwait(false);
            await SaveAsync();
        }

        public int Update(TEntity entityToUpdate)
        {
            TEntity repositoryEntityToUpdate = GetEntityFromRepositoryToUpdate(entityToUpdate);

            if (repositoryEntityToUpdate == null)
            {
                throw new KeyNotFoundException("Entity doesn't exists");
            }
            else
            {
                Context.Entry(repositoryEntityToUpdate).CurrentValues.SetValues(entityToUpdate);
            }

            return Save();
        }

        public void Update(TEntity repositoryEntityToUpdate, TEntity entityToUpdate)
        {
            Context.Entry(repositoryEntityToUpdate).CurrentValues.SetValues(entityToUpdate);
        }

        public async Task<int> UpdateAsync(TEntity entityToUpdate)
        {
            TEntity repositoryEntityToUpdate = await GetEntityFromRepositoryToUpdateAsync(entityToUpdate);

            if (repositoryEntityToUpdate == null)
            {
                throw new KeyNotFoundException("Entity doesn't exists");
            }
            else
            {
                await Task.Run(() => Update(repositoryEntityToUpdate, entityToUpdate)).ConfigureAwait(false);
            }

            return await SaveAsync();
        }

        protected virtual TEntity GetEntityFromRepositoryToUpdate(TEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }

        protected async virtual Task<TEntity> GetEntityFromRepositoryToUpdateAsync(TEntity entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public bool InsertRange(IEnumerable<TEntity> collectionEntities)
        {
            try
            {
                Context.Set<TEntity>().AddRange(collectionEntities);
                Save();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRange(IEnumerable<TEntity> collectionEntities)
        {
            try
            {
                List<TEntity> collectionListEntities = collectionEntities.ToList();

                foreach (TEntity collectionEntity in collectionListEntities)
                {
                    Context.Entry(collectionEntity).State = EntityState.Deleted;
                }

                Context.Set<TEntity>().RemoveRange(collectionListEntities);
                Save();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
