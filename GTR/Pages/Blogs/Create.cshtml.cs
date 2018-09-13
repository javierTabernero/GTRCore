using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GTR.Pages.Blogs
{
    public class CreateModel : BasePageModel
    {
        private readonly IBlogService _blogService;

        public CreateModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Blog Blog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _blogService.AddAsync(Blog, user);

            return RedirectToPage("./Index");
        }
    }
}