using GTR.Domain.Model.Data;
using GTR.Domain.Services.Base;
using GTR.Service.Services.Base;
using System.Threading.Tasks;

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

        public async Task<TEntity> AddAsync(TEntity entity, User usuario)
        {
            return await _baseServiceCrudLogic.AddAsync(entity, usuario);
        }

        public TEntity Add(TEntity entity, bool validate, User usuario)
        {
            return _baseServiceCrudLogic.Add(entity, validate, usuario);
        }

        public async Task<TEntity> AddAsync(TEntity entity, bool validate, User usuario)
        {
            return await _baseServiceCrudLogic.AddAsync(entity, validate, usuario);
        }

        public void Update(TEntity entity, User usuario)
        {
            _baseServiceCrudLogic.Update(entity, usuario);
        }

        public async Task UpdateAsync(TEntity entity, User usuario)
        {
            await _baseServiceCrudLogic.UpdateAsync(entity, usuario);
        }

        public void Delete(TEntityKey entityId, User usuario)
        {
            _baseServiceCrudLogic.Delete(entityId, usuario);
        }

        public async Task DeleteAsync(TEntityKey entityId, User usuario)
        {
            await _baseServiceCrudLogic.DeleteAsync(entityId, usuario);
        }
    }
}