using A3.Library.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.Users
{
    public class UsersService : ServiceBase<UsersService>
    {
        public UsersService(ILogger<UsersService> logger) : base(logger)
        {
        }
    }
}
