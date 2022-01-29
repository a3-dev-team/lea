using System.ComponentModel.DataAnnotations;

namespace A3.Shared.WebApi.Core.Users.Models
{
    public class SignInInformationDto
    {
        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
