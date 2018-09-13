using GTR.Domain.Model.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GTR.Pages.Base
{
    public class BasePageModel: PageModel
    {
        protected readonly User user;

        public BasePageModel()
        {
            user = new User()
            {
                Franquicia = "00626",
                UserCode = "00001",
                IdIdioma = 1
            };
        }
    }
}