using GTR.CrossCutting.Mapping;
using GTR.Domain.Logic.Services.Base;
using GTR.Domain.Model.Data;
using GTR.Domain.Services;
using GTR.Domain.Validations;
using GTR.Repository.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTR.Domain.Logic.Services
{
    public class PostLogic : BaseServiceCrudLogic<Post, Repository.Model.Post>, IPostLogic
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostValidator _postValidator;

        public PostLogic(IMapper mapper, IPostRepository postRepository, IPostValidator postValidator) : base(mapper, postRepository, postValidator)
        {
            _postRepository = postRepository;
            _postValidator = postValidator;
        }

        public List<Post> GetByBlogId(int blogId, User user)
        {
            IEnumerable<Repository.Model.Post> repositoryPost = _postRepository.GetByBlogId(blogId, UserToRepositoryEntity(user));

            return GetDomainEntitiesFromRepositoryEntities(repositoryPost).ToList();
        }

        public async Task<List<Post>> GetByBlogIdAsync(int blogId, User user)
        {
            IEnumerable<Repository.Model.Post> repositoryPost = await _postRepository.GetByBlogIdAsync(blogId, UserToRepositoryEntity(user));

            return GetDomainEntitiesFromRepositoryEntities(repositoryPost).ToList();
        }

        public Post GetById(int id, User user)
        {
           return GetDomainEntityFromRepositoryEntity( _postRepository.GetById(id, UserToRepositoryEntity(user)));
        }

        public async Task<Post> GetByIdAsync(int id, User user)
        {
            return GetDomainEntityFromRepositoryEntity(await _postRepository.GetByIdAsync(id, UserToRepositoryEntity(user)));
        }
    }
}