using GTR.Domain.Model.Data;
using GTR.Domain.Services.Base;
using GTR.Service.Services.Base;

namespace GTR.Service.Logic.Services.Base
{
    public class BaseServiceCrudLogic<TEntity, TEntityKey> : IBaseServiceCrud<TEntity, TEntityKey>
    {
        private readonly IBaseServiceCrudLogic<TEntity, TEntityKey> _baseServiceCrudLogic;

        public BaseServiceCrudLogic(IBaseServiceCrudLogic<TEntity, TEntityKey> baseServiceCrudLogic)
        {
            _baseServiceCrudLogic = baseServiceCrudLogic;
        }

        public TEntity Add(TEntity entity, User usuario)
        {
            return _baseServiceCrudLogic.Add(entity, usuario);
        }

        public TEntity Add(TEntity entity, bool validate, User usuario)
        {
            return _baseServiceCrudLogic.Add(entity, validate, usuario);
        }

        public void Delete(TEntityKey entityId, User usuario)
        {
            _baseServiceCrudLogic.Delete(entityId, usuario);
        }

        public void Update(TEntity entity, User usuario)
        {
            _baseServiceCrudLogic.Update(entity, usuario);
        }
    }
}
