using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace GTR.Pages.Posts
{
    public class CreateModel : BasePageModel
    {
        private readonly IPostService _postService;

        public CreateModel(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult OnGet(int id)
        {
            Post = new Post() { BlogId = id };

            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _postService.Add(Post, user);

            return RedirectToPage("/Blogs/Index", new { Id = Post.BlogId });
        }
    }
}