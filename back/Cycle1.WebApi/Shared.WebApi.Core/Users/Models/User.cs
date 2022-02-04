namespace A3.Shared.WebApi.Core.Users.Models
{
    public class User
    {
        public int Id { get; init; } = -1;

        public string FirstName { get; init; } = string.Empty;

        public string LastName { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public string Role { get; init; } = string.Empty;
    }
}
