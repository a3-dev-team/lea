using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace A3.Shared.WebApi.Core.Users.Models
{
    public class User
    {
        [Required]
        public int Id { get; init; } = -1;

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; init; } = string.Empty;


        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Role { get; set; } = string.Empty;

    }

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
    }
}
