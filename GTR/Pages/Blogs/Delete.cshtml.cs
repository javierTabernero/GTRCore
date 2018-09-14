using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _blogService.GetByIdAsync(id.Value, user);

            if (Blog == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _blogService.DeleteAsync(id.Value, user);
            }
            catch(KeyNotFoundException kex)
            {
                SetKeyNotFoundModelError();
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}