using GTR.CrossCutting.DependencyInjection;
using GTR.CrossCutting.Enums;
using GTR.Domain.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace GTR.Identity
{
    public class UserIdentity : IUserIdentity
    {
        public User GetActiveUser()
        {
            User user = null;
            try
            {
                IClaimsUserInterpreter claimsUserInterpreter = DependencyInjector.GetService<IClaimsUserInterpreter>();
                IEnumerable<Claim> claims = claimsUserInterpreter.GetClaims();

                if (claims != null)
                {
                    user = new User
                    {
                        Id = new Guid(claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value),
                        Name = claims.First(claim => claim.Type == ClaimTypes.Name).Value,
                        Email = claims.First(claim => claim.Type == ClaimTypes.Email).Value,
                        Role = (Role)Enum.Parse(typeof(Role), claims.First(claim => claim.Type == ClaimTypes.Role).Value, true),
                        Country = claims.First(claim => claim.Type == ClaimTypes.Country).Value,
                    };
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}