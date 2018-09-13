using GTR.CrossCutting.Exceptions;
using GTR.CrossCutting.Mapping;
using GTR.Domain.Model.Data;
using GTR.Domain.Services.Base;
using GTR.Domain.Validations;
using GTR.Repository.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTR.Domain.Logic.Services.Base
{
    public class BaseServiceCrudLogic<TDomainEntity, TRepositoryEntity> : BaseServiceLogic<TDomainEntity, TRepositoryEntity>,
       IBaseServiceCrudLogic<TDomainEntity, int>
       where TDomainEntity : class
       where TRepositoryEntity : class
    {
        private readonly IBaseRepositoryCrud<TRepositoryEntity, int> _baseRepositoryCrud;
        private readonly IValidator<TRepositoryEntity> _entityValidator;

        public BaseServiceCrudLogic(IMapper mapper, IBaseRepositoryCrud<TRepositoryEntity, int> baseRepositoryCrud, IValidator<TRepositoryEntity> entityValidator)
            : base(mapper)
        {
            _baseRepositoryCrud = baseRepositoryCrud;
            _entityValidator = entityValidator;
        }

        public virtual TDomainEntity Add(TDomainEntity entity, User usuario)
        {
            TRepositoryEntity entityRepository = GetValidRepositoryEntityFormDomainEntity(entity, true, usuario);
            SpecificEntityAddOperations(entityRepository, entity);
            _baseRepositoryCrud.Add(entityRepository);

            return GetDomainEntityFromRepositoryEntity(entityRepository);
        }

        public virtual TDomainEntity Add(TDomainEntity entity, bool validate, User usuario)
        {
            TRepositoryEntity entityRepository = GetValidRepositoryEntityFormDomainEntity(entity, validate, usuario);
            SpecificEntityAddOperations(entityRepository, entity);
            _baseRepositoryCrud.Add(entityRepository);

            return GetDomainEntityFromRepositoryEntity(entityRepository);
        }

        public virtual void Update(TDomainEntity entity, User usuario)
        {
            TRepositoryEntity entityRepository = GetValidRepositoryEntityFormDomainEntity(entity, true, usuario);
            SpecificEntityUpdateOperations(entityRepository, entity);
            _baseRepositoryCrud.Update(entityRepository);

            entity = GetDomainEntityFromRepositoryEntity(entityRepository);
        }

        public virtual void Delete(int entityId, User usuario)
        {
            ThrowExceptionIfDeletionIsNotPosible(entityId, usuario);

            _baseRepositoryCrud.Delete(_baseRepositoryCrud.GetById(entityId));
        }

        public async virtual Task<TDomainEntity> AddAsync(TDomainEntity entity, User usuario)
        {
            TRepositoryEntity entityRepository = GetValidRepositoryEntityFormDomainEntity(entity, true, usuario);
            SpecificEntityAddOperations(entityRepository, entity);
            await _baseRepositoryCrud.AddAsync(entityRepository);

            return GetDomainEntityFromRepositoryEntity(entityRepository);
        }

        public async virtual Task<TDomainEntity> AddAsync(TDomainEntity entity, bool validate, User usuario)
        {
            TRepositoryEntity entityRepository = GetValidRepositoryEntityFormDomainEntity(entity, validate, usuario);
            SpecificEntityAddOperations(entityRepository, entity);
            await _baseRepositoryCrud.AddAsync(entityRepository);

            return GetDomainEntityFromRepositoryEntity(entityRepository);
        }

        public async virtual Task UpdateAsync(TDomainEntity entity, User usuario)
        {
            TRepositoryEntity entityRepository = GetValidRepositoryEntityFormDomainEntity(entity, true, usuario);
            SpecificEntityUpdateOperations(entityRepository, entity);
            await _baseRepositoryCrud.UpdateAsync(entityRepository);

            entity = GetDomainEntityFromRepositoryEntity(entityRepository);
        }

        public async virtual Task DeleteAsync(int entityId, User usuario)
        {
            ThrowExceptionIfDeletionIsNotPosible(entityId, usuario);

            await _baseRepositoryCrud.DeleteAsync(_baseRepositoryCrud.GetById(entityId));
        }

        public virtual void Validate(TDomainEntity entity, User usuario)
        {
            TRepositoryEntity repositoryEntity = GetRepositoryEntityFromDomainEntity(entity);

            ThrowExceptionIfDataIsInvalid(repositoryEntity, usuario);
        }

        protected void DeleteValidations(int entityId, User usuario)
        {
            ThrowExceptionIfDeletionIsNotPosible(entityId, usuario);
        }

        protected void ThrowExceptionIfDataIsInvalid(List<KeyValuePair<string, string>> validationMessages)
        {
            if (validationMessages.Any())
            {
                throw new ValidationException(validationMessages);
            }
        }

        protected TRepositoryEntity GetValidRepositoryEntityFormDomainEntity(TDomainEntity domainEntity, bool validate, User usuario)
        {
            TRepositoryEntity repositoryEntity = GetRepositoryEntityFromDomainEntity(domainEntity);

            if (validate)
            {
                ThrowExceptionIfDataIsInvalid(repositoryEntity, usuario);
            }

            return repositoryEntity;
        }

        private void ThrowExceptionIfDeletionIsNotPosible(int entityId, User usuario)
        {
            IEnumerable<KeyValuePair<string, string>> validationMessages = _entityValidator.GetDeleteValidationMessages(entityId, usuario).ToList();

            ThrowExceptionIfDataIsInvalid(validationMessages.ToList());
        }

        private void ThrowExceptionIfDataIsInvalid(TRepositoryEntity repositoryEntity, User usuario)
        {
            IEnumerable<KeyValuePair<string, string>> validationMessages = _entityValidator.GetValidationMessages(repositoryEntity, usuario).ToList();

            ThrowExceptionIfDataIsInvalid(validationMessages.ToList());
        }

        protected virtual void SpecificEntityAddOperations(TRepositoryEntity repositoryEntity, TDomainEntity domainEntity)
        {

        }

        protected virtual void SpecificEntityUpdateOperations(TRepositoryEntity repositoryEntity, TDomainEntity domainEntity)
        {

        }
    }
}