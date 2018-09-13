using GTR.CrossCutting.Mapping;
using GTR.Domain.Model.Data;
using System.Collections.Generic;
using System.Linq;

namespace GTR.Domain.Logic.Services.Base
{
    public class BaseServiceLogic<TDomainEntity, TRepositoryEntity>
        where TDomainEntity : class
        where TRepositoryEntity : class
    {
        private readonly IMapper _mapper;

        public BaseServiceLogic(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected TRepositoryEntity GetRepositoryEntityFromDomainEntity(TDomainEntity domainEntity)
        {
            return _mapper.Map<TRepositoryEntity>(domainEntity);
        }

        protected TRepository GetRepositoryEntityFromDomainEntity<TRepository, TDomain>(TDomain domainEntity)
        {
            return _mapper.Map<TRepository>(domainEntity);
        }

        protected TDomain GetDomainEntityFromRepositoryEntity<TDomain, TRepository>(TRepository repositoryEntity)
        {
            return _mapper.Map<TDomain>(repositoryEntity);
        }

        protected TDomainEntity GetDomainEntityFromRepositoryEntity(TRepositoryEntity repositoryEntity)
        {
            return _mapper.Map<TDomainEntity>(repositoryEntity);
        }

        protected IEnumerable<TDomainEntity> GetDomainEntitiesFromRepositoryEntities(IEnumerable<TRepositoryEntity> repositoryEntities)
        {
            return repositoryEntities.Select(GetDomainEntityFromRepositoryEntity).ToList();
        }

        protected Repository.Model.Data.Users.User UserToRepositoryEntity(User user)
        {
            return _mapper.Map<Repository.Model.Data.Users.User>(user);
        }
    }
}
