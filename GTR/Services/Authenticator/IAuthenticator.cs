using System.Security.Claims;
using System.Threading.Tasks;

namespace GTR.Services.Authenticator
{
    public interface IAuthenticator
    {
        Task SignInAsync(ClaimsPrincipal principal);

        Task SignOutAsync();
    }
}