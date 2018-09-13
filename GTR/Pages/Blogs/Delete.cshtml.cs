using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GTR.Pages.Blogs
{
    public class DeleteModel : BasePageModel
    {
        private readonly IBlogService _blogService;

        public DeleteModel(IBlogService blogService)
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

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                _blogService.Delete(id.Value, user);
            }
            catch(KeyNotFoundException kex)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
