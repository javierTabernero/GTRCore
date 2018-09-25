using GTR.Model;
using GTR.Pages.Base;
using GTR.Service.Services.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GTR.Pages.Account
{
    public class RegisterModel : BasePageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }

        public IActionResult OnGet()
        {
            RegisterViewModel = new RegisterViewModel();
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
                _userService.Register(RegisterViewModel.Name, RegisterViewModel.Email, RegisterViewModel.Password, RegisterViewModel.Role);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                RegisterViewModel = new RegisterViewModel();
                return Page();
            }

            return RedirectToPage("/Account/login");
        }
    }
}