using System.Resources;
using A3.Library.Mvc;
using A3.Library.Mvc.Jwt;
using A3.Library.Results;
using A3.Shared.WebApi.Core.Users;
using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Shared.WebApi.Controllers.Users
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class UsersController : ControllerBase<UsersController, IUsersService>
    {
        private readonly JwtSettings _jwtSettings;

        protected override ResourceManager? ResourceManager => UsersResources.ResourceManager;

        /// <summary>
        /// Connexion par cookie
        /// </summary>
        /// <param name="signInInformation"></param>
        /// <returns></returns>
        [HttpPost("cookiesignin")]
        [AllowAnonymous]
        public IActionResult CookieSignIn(SignInInformationDto signInInformation)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ValidationProblem(this.ModelState);
            }

            Result<User?> resultUser = this.Service.GetUserForSignIn(signInInformation);
            if (!resultUser.IsValidAndValued())
            {
                return this.PostActionResult(resultUser);
            }

            return this.SignIn(resultUser.Value.ToClaimsPrincipal(CookieAuthenticationDefaults.AuthenticationScheme));
        }

        /// <summary>
        /// Déconnexion par cookie
        /// </summary>
        /// <returns></returns>
        [HttpPost("cookiesignout")]
        public IActionResult CookieSignOut()
        {
            return this.SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Connexion par token
        /// </summary>
        /// <param name="signInInformation"></param>
        /// <returns></returns>
        [HttpPost("tokensignin")]
        [AllowAnonymous]
        public IActionResult TokenSignIn(SignInInformationDto signInInformation)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ValidationProblem(this.ModelState);
            }

            Result<User?> resultUser = this.Service.GetUserForSignIn(signInInformation);
            if (!resultUser.IsValidAndValued())
            {
                return this.PostActionResult(resultUser);
            }
            return this.Ok(JwtProvider.Provide(resultUser.Value.ToClaims(), this._jwtSettings));
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="jwtSettings"></param>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public UsersController(JwtSettings jwtSettings, IUsersService service, ILogger<UsersController> logger) : base(service, logger)
        {
            this._jwtSettings = jwtSettings;
        }
    }
}
