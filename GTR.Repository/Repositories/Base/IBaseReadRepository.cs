using GTR.Repository.Model.Data.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Repository.Repositories.Base
{
    public interface IBaseReadRepository<TEntity, TEntityKey> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity GetById(TEntityKey entityId);

        Task<TEntity> GetByIdAsync(TEntityKey entityId);

        bool ExistsId(TEntityKey id);

        Task<bool> ExistsIdAsync(TEntityKey id);
    }
}