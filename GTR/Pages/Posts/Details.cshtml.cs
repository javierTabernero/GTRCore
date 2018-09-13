using GTR.Domain.Model.Data;
using GTR.Pages.Base;
using GTR.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GTR.Pages.Posts
{
    public class DetailsModel : BasePageModel
    {
        private readonly IPostService _postService;

        public DetailsModel(IPostService postService)
        {
            _postService = postService;
        }

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _postService.GetByIdAsync(id.Value, base.user);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}