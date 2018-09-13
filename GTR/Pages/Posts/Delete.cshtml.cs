using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult OnPost()//int? id
        {
            if (Post == null)
            {
                return NotFound();
            }

            try
            {
                _postService.Delete(Post.PostId, user);
            }
            catch (KeyNotFoundException kex)
            {
                return NotFound();
            }

            return RedirectToPage("/Blogs/Index", new { Id = Post.BlogId });
        }
    }
}