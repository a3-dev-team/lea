using System.ComponentModel.DataAnnotations;

namespace A3.Shared.WebApi.Core.Users.Models
{
    public class SignInInformation
    {
        [Required]
        [EmailAddress]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
