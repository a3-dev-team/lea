using A3.Library.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Shared.WebApi.Core.Users
{
    public class UsersService : ServiceBase<UsersService>, IUsersService
    {
        public UsersService(ILogger<UsersService> logger) : base(logger) { }
    }
}
