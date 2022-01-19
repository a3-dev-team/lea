using A3.Library.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Shared.WebApi.Controllers.Users
{
    internal class UsersController : ControllerBase<UsersController>
    {
        public UsersController(ILogger<UsersController> logger) : base(logger) { }
    }
}
