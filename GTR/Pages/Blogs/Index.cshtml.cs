//using GTR.CrossCutting.Logging;
using GTR.CrossCutting.Enums;
using GTR.Domain.Model.Data;
using GTR.Identity;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace GTR.Pages.Blogs
{
    //[Authorize(Roles = "Admin,PowerUser")]
    [Authorize]
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

        public IList<Blog> Blogs { get; set; }

        public IList<Post> Posts { get; set; }

        public int BlogId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            IIdentity logeduser = base.User.Identity;
            _logger.LogInformation("Blogs.Index.OnGet");
            Blogs = await _blogService.GetAllAsync();

            if (id != null)
            {
                BlogId = id.Value;
                Posts = await _postService.GetByBlogIdAsync(BlogId, user);
            }

            //Response.Cookies.Append(
            //    CookieRequestCultureProvider.DefaultCookieName,
            //    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(user.Country)),
            //    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            //);

            return Page();
        }

        [Authorize(Roles = nameof(Role.User))]
        public PartialViewResult OnGetDivItemPartial()
        {
            List<string> lstString = new List<string>
            {
                $"{Resources.Resources.Resources.UI_Val} 1",
                $"{Resources.Resources.Resources.UI_Val} 2",
                $"{Resources.Resources.Resources.UI_Val} 3",
            };

            return new PartialViewResult
            {
                ViewName = "_DivItemsPartial",
                ViewData = new ViewDataDictionary<List<string>>(ViewData, lstString)
            };
        }

        public JsonResult OnGetList()
        {
            List<string> lstString = new List<string>
            {
                $"{Resources.Resources.Resources.UI_Val} 1",
                $"{Resources.Resources.Resources.UI_Val} 2",
                $"{Resources.Resources.Resources.UI_Val} 3",
            };

            return new JsonResult(lstString);
        }
    }
}