using GTR.Domain.Model.Data;
using GTR.Domain.Services;
using GTR.Service.Logic.Services.Base;
using GTR.Service.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace GTR.Service.Logic.Services
{
    public class BlogService : BaseServiceCrudLogic<Blog, int>, IBlogService
    {
        private readonly ILogger<BlogService> _logger;
        private readonly IBlogLogic _blogLogic;

        public BlogService(ILogger<BlogService> logger, IBlogLogic blogLogic): base(blogLogic)
        {
            _blogLogic = blogLogic;
            _logger = logger;
        }

        public Blog GetById(int id, User user)
        {
            _logger.LogInformation("BlogService.GetById");
            return _blogLogic.GetById(id, user);
        }

        public List<Blog> GetAll()
        {
            _logger.LogInformation("BlogService.GetAll");
            return _blogLogic.GetAll();
        }
    }
}