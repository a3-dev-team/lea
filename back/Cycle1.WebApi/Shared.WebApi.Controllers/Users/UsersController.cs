using System.Resources;
using A3.Library.Mvc;
using A3.Library.Mvc.Jwt;
using A3.Library.Results;
using A3.Shared.WebApi.Core.Users;
using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace A3.Shared.WebApi.Controllers.Users
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class UsersController : ControllerBase<UsersController, IUsersService>
    {
        private readonly JwtSettings _jwtSettings;

        protected override ResourceManager? ResourceManager => UsersResources.ResourceManager;

        [HttpPost("signin")]
        [AllowAnonymous]
        public IActionResult SignIn(SignInInformation signInInformation)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ValidationProblem(this.ModelState);
            }

            Result<AuthenticatedUser?> authenticatedUser = this.Service.GetAuthenticatedUser(signInInformation, this._jwtSettings);
            return this.PostActionResult(authenticatedUser);
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="jwtSettings"></param>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public UsersController(IOptions<JwtSettings> jwtSettings, IUsersService service, ILogger<UsersController> logger) : base(service, logger)
        {
            this._jwtSettings = jwtSettings.Value;
        }
    }
}
