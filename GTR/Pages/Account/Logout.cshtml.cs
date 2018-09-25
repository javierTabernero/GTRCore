using GTR.Pages.Base;
using GTR.Services.Authenticator;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GTR.Pages.Account
{
    public class LogoutModel : BasePageModel
    {
        private readonly IAuthenticator _authenticator;

        public LogoutModel(IAuthenticator authenticator )
        {
            _authenticator = authenticator;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Blogs/Index");
            }

            await _authenticator.SignOutAsync();


            return RedirectToPage("/Blogs/Index");
        }
    }
}