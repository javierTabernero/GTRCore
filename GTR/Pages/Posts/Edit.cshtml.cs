using GTR.CrossCutting.Exceptions;
using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTR.Pages.Posts
{
    public class EditModel : BasePageModel
    {
        private readonly IPostService _postService;

        public EditModel(IPostService postService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _postService.UpdateAsync(Post, user);
            }
            catch (ValidationException vex)
            {
                SetModelError(vex);
                return Page();
            }
            catch (KeyNotFoundException kex)
            {
                SetKeyNotFoundModelError();
                return Page();
            }

            return RedirectToPage("/Blogs/Index", new { Id = Post.BlogId });
        }
    }
}