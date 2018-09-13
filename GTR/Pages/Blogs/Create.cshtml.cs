using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _blogService.Add(Blog, user);

            return RedirectToPage("./Index");
        }
    }
}