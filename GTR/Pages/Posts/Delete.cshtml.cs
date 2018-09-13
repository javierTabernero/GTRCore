using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Pages.Posts
{
    public class DeleteModel : BasePageModel
    {
        private readonly IPostService _postService;

        public DeleteModel(IPostService postService)
        {
            _postService = postService;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _postService.GetByIdAsync(id.Value, user);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Post == null)
            {
                return NotFound();
            }

            try
            {
                await _postService.DeleteAsync(Post.PostId, user);
            }
            catch (KeyNotFoundException kex)
            {
                return NotFound();
            }

            return RedirectToPage("/Blogs/Index", new { Id = Post.BlogId });
        }
    }
}