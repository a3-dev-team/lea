using A3.Shared.WebApi.Core.Users;
using A3.Shared.WebApi.Core.Users.Passwords;
using A3.Shared.WebApi.Dal.Users;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    internal static class SharedExtension
    {
        private static void AddUsersServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IUsersService, UsersService, IUsersDal, UsersDal, UsersProblemDetailsResolver>
                (services, (serviceProvider) => new UsersProblemDetailsResolver());
        }

        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            AddUsersServices(services);
            return services;
        }
    }
}
