using A3.Library.Mvc;
using A3.Library.Mvc.Jwt;
using A3.Library.Results;
using A3.Shared.WebApi.Core.Users.Helpers;
using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.Extensions.Logging;

namespace A3.Shared.WebApi.Core.Users
{
    public class UsersService : ServiceBase<UsersService>, IUsersService
    {
        private readonly IUsersDal _usersDal;
        private readonly IPasswordHasher _passwordHasher;

        public UsersService(ILogger<UsersService> logger, IUsersDal usersDal, IPasswordHasher passwordHasher) : base(logger)
        {
            this._usersDal = usersDal;
            this._passwordHasher = passwordHasher;
        }

        public async Task<Result<AuthenticatedUser?>> GetAuthenticatedUserAsync(SignInInformation signInInformation, JwtSettings jwtSettings)
        {
            Result<AuthenticatedUser?> result = new Result<AuthenticatedUser?>();

            Result<User> userResult = await this._usersDal.GetUserByEMail(signInInformation.Login);

            if (userResult.IsValid && userResult.Value != null)
            {
                (bool passwordVerified, bool passwordNeedsUpgrade) = this._passwordHasher.Check(userResult.Value.Password, signInInformation.Password);
                if (passwordVerified)
                {
                    if (passwordNeedsUpgrade)
                    {
                        // Si le mot de passe ne respecte pas le "nouveau" nombre de cyle de hachage paramétré, on le régénère
                        userResult.Value.Password = this._passwordHasher.Hash(signInInformation.Password);
                        await this._usersDal.UpdateUser(userResult.Value);
                    }
                    result.Value = this.GetAuthenticatedUserFromUser(userResult.Value, jwtSettings);
                }
                else
                {
                    result.AddError("lala");
                }
            }
            else
            {
                result.AddError("Users_PE_UserSignIn.IncorrectSignInInformation");
            }

            return result;
        }

        private AuthenticatedUser GetAuthenticatedUserFromUser(User user, JwtSettings jwtSettings)
        {
            return new AuthenticatedUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                Token = JwtProvider.ProvideToken(user.ToClaims(), jwtSettings)
            };
        }
    }
}
