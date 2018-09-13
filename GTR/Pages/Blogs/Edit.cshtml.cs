using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _blogService.UpdateAsync(Blog, user);
            }
            catch (KeyNotFoundException kex)
            {
                return NotFound();
            }
           
            return RedirectToPage("./Index");
        }
    }
}