//using GTR.CrossCutting.Logging;
using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task OnGetAsync(int ? id)
        {
            _logger.LogInformation("Blogs.Index.OnGet");
            Blogs = await _blogService.GetAllAsync();

            if (id != null)
            {
                BlogId = id.Value;
                Posts = await _postService.GetByBlogIdAsync(BlogId, user);
            }
        }

        public JsonResult OnGetList()
        {
            List<string> lstString = new List<string>
            {
                "Val 1",
                "Val 2",
                "Val 3"
            };
            return new JsonResult(lstString);
        }
    }
}