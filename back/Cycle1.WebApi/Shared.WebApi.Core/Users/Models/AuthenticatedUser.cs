namespace A3.Shared.WebApi.Core.Users.Models
{
    public class AuthenticatedUser
    {
        public string FirstName { get; init; } = string.Empty;

        public string LastName { get; init; } = string.Empty;

        public string Email { get; set; }

        public string Role { get; init; } = string.Empty;

        public string Token { get; init; } = string.Empty;
    }
}
