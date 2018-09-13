﻿using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace GTR.Pages.Blogs
{
    public class DetailsModel : BasePageModel
    {
        private readonly IBlogService _blogService;

        public DetailsModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public Blog Blog { get; set; }

       // public async Task<IActionResult> OnGetAsync(int? id)
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
    }
}
