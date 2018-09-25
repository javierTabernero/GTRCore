using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace GTR.Identity
{
    public class ClaimsUserInterpreter : IClaimsUserInterpreter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsUserInterpreter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Claim> GetClaims()
        {
            IEnumerable<Claim> claims = null;
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            if (httpContext.User.Identity.IsAuthenticated)
            {
                claims = httpContext.User.Claims
                .Where(x =>
                    x.Type.Contains("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/")
                    || x.Type.Contains("http://schemas.microsoft.com/ws/2008/06/identity/claims")
                ).ToList();
            }

            return claims;
        }
    }
}