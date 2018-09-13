//using GTR.CrossCutting.Logging;
using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace GTR.Pages.Blogs
{
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogService _blogService;
        private readonly IPostService _postService;

        public IndexModel(ILogger<IndexModel> logger, IBlogService blogService, IPostService postService)
        {
            _logger = logger;
            _blogService = blogService;
            _postService = postService;
        }

        public IList<Blog> Blogs { get;set; }

        public IList<Post> Posts { get; set; }

        public int BlogId { get; set; }

        public void OnGet(int ? id)
        {
            _logger.LogInformation("Blogs.Index.OnGet");
            Blogs = _blogService.GetAll();

            if (id != null)
            {
                BlogId = id.Value;
                Posts = _postService.GetByBlogId(BlogId, user);
            }
        }
    }
}