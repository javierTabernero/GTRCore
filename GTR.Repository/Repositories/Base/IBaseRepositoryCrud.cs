using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Repository.Repositories.Base
{
    public interface IBaseRepositoryCrud<TEntity, TEntityKey> : IBaseReadRepository<TEntity, TEntityKey> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        int Update(TEntity entityToUpdate);

        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entityToUpdate);

        bool InsertRange(IEnumerable<TEntity> collectionEntities);
        bool DeleteRange(IEnumerable<TEntity> collectionEntities);
    }
}