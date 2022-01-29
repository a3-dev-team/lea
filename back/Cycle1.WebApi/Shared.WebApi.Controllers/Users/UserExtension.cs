using System.Security.Claims;
using A3.Shared.WebApi.Core.Users.Models;

namespace A3.Shared.WebApi.Controllers.Users
{
    internal static class UserExtension
    {
        public static IEnumerable<Claim> ToClaims(this User user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("ZOP", "sdfgsdg")
            };
        }

        public static ClaimsPrincipal ToClaimsPrincipal(this User user, string authenticationType)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(user.ToClaims(), authenticationType));
        }
    }
}
