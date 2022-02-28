using System.ComponentModel.DataAnnotations;

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
}
