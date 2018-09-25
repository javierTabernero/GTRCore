using GTR.Domain.Model.Data;
using GTR.Model;
using GTR.Pages.Base;
using GTR.Service.Services.Account;
using GTR.Services.Authenticator;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GTR.Pages.Account
{
    public class loginModel : BasePageModel
    {
        private readonly IUserService _userService;
        private readonly IAuthenticator _authenticator;

        public loginModel(IUserService userService, IAuthenticator authenticator)
        {
            _userService = userService;
            _authenticator = authenticator;
        }

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _userService.Login(LoginViewModel.Email, LoginViewModel.Password);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return Page();
            }

            User user = _userService.Get(LoginViewModel.Email);
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Country, user.Country.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await _authenticator.SignInAsync(principal);

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(user.Country)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return RedirectToPage("/Blogs/Index");
        }
    }
}