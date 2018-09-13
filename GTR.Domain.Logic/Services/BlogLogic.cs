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
    public class BlogLogic : BaseServiceCrudLogic<Blog, Repository.Model.Blog>, IBlogLogic
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlogValidator _blogValidator;

        public BlogLogic(IMapper mapper, IBlogRepository blogRepository, IBlogValidator blogValidator) : base(mapper, blogRepository, blogValidator)
        {
            _blogRepository = blogRepository;
            _blogValidator = blogValidator;
        }

        public Blog GetById(int id, User user)
        {
            Repository.Model.Blog blog = _blogRepository.GetById(id, UserToRepositoryEntity(user));

            return GetDomainEntityFromRepositoryEntity(blog);
        }

        public async Task<Blog> GetByIdAsync(int id, User user)
        {
            Repository.Model.Blog blog = await _blogRepository.GetByIdAsync(id, UserToRepositoryEntity(user));

            return GetDomainEntityFromRepositoryEntity(blog);
        }

        public List<Blog> GetAll()
        {
            IEnumerable<Repository.Model.Blog> repositoryPost = _blogRepository.GetAll();

            return GetDomainEntitiesFromRepositoryEntities(repositoryPost).ToList();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            IEnumerable<Repository.Model.Blog> repositoryPost = await _blogRepository.GetAllAsync();

            return GetDomainEntitiesFromRepositoryEntities(repositoryPost).ToList();
        }
    }
}