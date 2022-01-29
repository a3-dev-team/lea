using A3.Library.Results;
using A3.Shared.WebApi.Core.Users.Models;

namespace A3.Shared.WebApi.Core.Users
{
    public interface IUsersService
    {
        Result<User?> GetUserForSignIn(SignInInformationDto signInInformation);
    }
}
