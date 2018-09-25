using System.Collections.Generic;
using System.Security.Claims;

namespace GTR.Identity
{
    public interface IClaimsUserInterpreter
    {
        IEnumerable<Claim> GetClaims();
    }
}