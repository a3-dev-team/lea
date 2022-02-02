using A3.Library.Mvc;
using A3.Library.Mvc.Jwt;
using A3.Library.Results;
using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.Extensions.Logging;

namespace A3.Shared.WebApi.Core.Users
{
    public class UsersService : ServiceBase<UsersService>, IUsersService
    {
        public UsersService(ILogger<UsersService> logger) : base(logger) { }

        public Result<AuthenticatedUser?> GetAuthenticatedUser(SignInInformation signInInformation, JwtSettings jwtSettings)
        {
            Result<AuthenticatedUser?> result = new Result<AuthenticatedUser?>();
            string? userLogin = signInInformation.Login;

            if (string.IsNullOrWhiteSpace(userLogin) ||
                !userLogin.Equals("bdolet@isagri.fr", StringComparison.OrdinalIgnoreCase))
            {
                result.AddError("Users_PE_UserSignIn.IncorrectSignInInformation");
                return result;
            }

            User user = new User()
            {
                Id = 1,
                FirstName = "Bertrand",
                LastName = "DOLET",
                Email = "bdolet@isagri.fr",
                Role = "professeur"
            };

            result.Value = new AuthenticatedUser()
            {
                FirstName = "Bertrand",
                LastName = "DOLET",
                Role = "Professeur",
                Token = JwtProvider.ProvideToken(user.ToClaims(), jwtSettings)
            };
            return result;
        }
    }
}
