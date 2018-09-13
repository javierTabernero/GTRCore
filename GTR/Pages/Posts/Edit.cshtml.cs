using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = _postService.GetById(id.Value, user);

            if (Post == null)
            {
                return NotFound();
            } 

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _postService.Update(Post, user);
            }
            catch (KeyNotFoundException kex)
            {
                return NotFound();
            }

            return RedirectToPage("/Blogs/Index", new { Id = Post.BlogId });
        }
    }
}