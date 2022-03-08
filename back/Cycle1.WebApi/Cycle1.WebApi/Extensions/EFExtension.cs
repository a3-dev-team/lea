using A3.Lea.Cycle1.WebApi.Dal;
using A3.Shared.WebApi.Dal;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    public static class EFExtension
    {
        public static IServiceCollection AddEF(this IServiceCollection services, string connectionString)
        {
            //      MigrationAssembly : https://docs.microsoft.com/fr-fr/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
            //      => Permet de simplifier la commande de génération des migrations lorsque le DbContext n'est pas dans l'assembly de démarrage
            services.AddDbContext<Cycle1DbContext>(options =>
               options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("A3.Lea.Cycle1.WebApi")),
               ServiceLifetime.Singleton);

            services.AddDbContext<SharedDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("A3.Lea.Cycle1.WebApi")),
                ServiceLifetime.Singleton);

            return services;
        }
    }
}
