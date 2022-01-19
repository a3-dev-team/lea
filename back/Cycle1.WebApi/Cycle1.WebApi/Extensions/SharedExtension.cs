using A3.Shared.WebApi.Core.Users;
using A3.Shared.WebApi.Dal.MySql.Users;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    internal static class SharedExtension
    {
        private static void AddUsersServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IUsersService, UsersService, IUsersDal, UsersDalMySql, UsersProblemDetailsResolver>
                (services, (serviceProvider) => new UsersProblemDetailsResolver(0, 999));
        }

        public static void AddSharedServices(IServiceCollection services)
        {
            AddUsersServices(services);
        }
    }
}
