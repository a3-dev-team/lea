using A3.Library.Mvc;
using A3.Library.Results;
using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.Extensions.Logging;

namespace A3.Shared.WebApi.Core.Users
{
    public class UsersService : ServiceBase<UsersService>, IUsersService
    {
        public UsersService(ILogger<UsersService> logger) : base(logger) { }

        public Result<User?> GetUserForSignIn(SignInInformationDto signInInformation)
        {
            Result<User?> result = new Result<User?>();
            string? userId = signInInformation.UserId;

            if (string.IsNullOrWhiteSpace(userId) ||
                !userId.Equals("bertrand", StringComparison.OrdinalIgnoreCase))
            {
                result.AddError("Users_PE_UserSignIn.IncorrectSignInInformation");
                return result;
            }
            result.Value = new User(userId, userId);
            return result;
        }
    }
}
