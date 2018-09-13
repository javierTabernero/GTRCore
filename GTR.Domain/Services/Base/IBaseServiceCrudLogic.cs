using GTR.Domain.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTR.Domain.Services.Base
{
    public interface IBaseServiceCrudLogic<TEntity, TEntityKey>
    {
        TEntity Add(TEntity entity, User usuario);
        TEntity Add(TEntity entity, bool validate, User usuario);
        void Update(TEntity entity, User usuario);
        void Delete(TEntityKey entityId, User usuario);

        Task<TEntity> AddAsync(TEntity entity, User usuario);
        Task<TEntity> AddAsync(TEntity entity, bool validate, User usuario);
        Task UpdateAsync(TEntity entity, User usuario);
        Task DeleteAsync(TEntityKey entityId, User usuario);

        void Validate(TEntity entity, User usuario);
    }
}