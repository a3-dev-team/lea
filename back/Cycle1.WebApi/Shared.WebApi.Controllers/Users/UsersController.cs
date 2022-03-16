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
    public class UsersController : ControllerBase<UsersController, IUserService>
    {
        private readonly JwtSettings _jwtSettings;

        protected override ResourceManager? ResourceManager => UserResources.ResourceManager;

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignInAsync([FromBody] SignInInformation signInInformation)
        {
            if (!this.ModelState.IsValid)
            {
                return this.ValidationProblem(this.ModelState);
            }

            Result<AuthenticatedUser?> authenticatedUser = await this.Service.GetAuthenticatedUserAsync(signInInformation, this._jwtSettings);
            return this.PostActionResult(authenticatedUser);
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="jwtSettings"></param>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public UsersController(IOptions<JwtSettings> jwtSettings, IUserService service, ILogger<UsersController> logger) : base(service, logger)
        {
            this._jwtSettings = jwtSettings.Value;
        }
    }
}
