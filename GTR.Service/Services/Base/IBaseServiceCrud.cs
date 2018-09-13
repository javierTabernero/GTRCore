using GTR.Domain.Model.Data;

namespace GTR.Service.Services.Base
{
    public interface IBaseServiceCrud<TEntity, TEntityKey>
    {
        TEntity Add(TEntity entity, User usuario);
        TEntity Add(TEntity entity, bool validate, User usuario);
        void Update(TEntity entity, User usuario);
        void Delete(TEntityKey entityId, User usuario);
    }
}
