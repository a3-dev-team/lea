using System.ComponentModel.DataAnnotations;

namespace A3.Shared.WebApi.Core.Users.Models
{
    public class SignInInformation
    {
        // [Required(AllowEmptyStrings = false)]
        // [EmailAddress]
        public string Login { get; init; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        public string Password { get; init; } = string.Empty;
    }
}
