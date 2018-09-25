using GTR.CrossCutting.DependencyInjection;
using GTR.CrossCutting.Exceptions;
using GTR.Domain.Model.Data;
using GTR.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace GTR.Pages.Base
{
    public class BasePageModel: PageModel
    {
        protected readonly User user;

        public BasePageModel()
        {
            IUserIdentity userIdentity = DependencyInjector.GetService<IUserIdentity>();
            user = userIdentity.GetActiveUser();
        }

        public void SetModelError(ValidationException vex)
        {
            foreach (KeyValuePair<string, string> mesage in vex.Messages)
            {
                ModelState.AddModelError(string.Empty, string.Format(Resources.Resources.Resources.UI_Error, mesage.Key, mesage.Value));
            }
        }

        public void SetKeyNotFoundModelError()
        {
            ModelState.AddModelError(string.Empty, Resources.Resources.Resources.UI_NoKey);
        }
    }
}