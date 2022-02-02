using System.Security.Claims;

namespace A3.Shared.WebApi.Core.Users.Models
{
    internal static class UserExtension
    {
        public static IEnumerable<Claim> ToClaims(this User user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
        }

        public static ClaimsPrincipal ToClaimsPrincipal(this User user, string authenticationType)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(user.ToClaims(), authenticationType));
        }
    }
}
