using GTR.Domain.Model.Data;
using System.Threading.Tasks;

namespace GTR.Service.Services.Base
{
    public interface IBaseServiceCrud<TEntity, TEntityKey>
    {
        TEntity Add(TEntity entity, User usuario);

        Task<TEntity> AddAsync(TEntity entity, User usuario);

        TEntity Add(TEntity entity, bool validate, User usuario);

        Task<TEntity> AddAsync(TEntity entity, bool validate, User usuario);

        void Update(TEntity entity, User usuario);

        Task UpdateAsync(TEntity entity, User usuario);

        void Delete(TEntityKey entityId, User usuario);

        Task DeleteAsync(TEntityKey entityId, User usuario);
    }
}