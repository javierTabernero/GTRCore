using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _postService.AddAsync(Post, user);

            return RedirectToPage("/Blogs/Index", new { Id = Post.BlogId });
        }
    }
}