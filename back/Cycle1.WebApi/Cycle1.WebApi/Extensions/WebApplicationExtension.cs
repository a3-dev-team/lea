using A3.Lea.Cycle1.WebApi.Dal;
using A3.Shared.WebApi.Dal;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication InitDB(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                DatabaseContext databaseContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                databaseContext.Database.EnsureDeleted();
                databaseContext.Database.EnsureCreated();
                databaseContext.AjouterDonnees();

                SharedDatabaseContext sharedDatabaseContext = serviceScope.ServiceProvider.GetRequiredService<SharedDatabaseContext>();
                sharedDatabaseContext.Database.EnsureDeleted();
                sharedDatabaseContext.Database.EnsureCreated();
                sharedDatabaseContext.AjouterDonnees();
            }

            return app;
        }
    }
}
