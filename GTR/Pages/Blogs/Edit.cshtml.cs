using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GTR.Pages.Blogs
{
    public class EditModel : BasePageModel
    {
        private readonly IBlogService _blogService;

        public EditModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = _blogService.GetById(id.Value, user);

            if (Blog == null)
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
                _blogService.Update(Blog, user);
            }
            catch (KeyNotFoundException kex)
            {
                return NotFound();
            }
           
            return RedirectToPage("./Index");
        }
    }
}