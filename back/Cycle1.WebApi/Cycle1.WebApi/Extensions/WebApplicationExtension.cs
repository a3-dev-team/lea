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
                Cycle1DbContext databaseContext = serviceScope.ServiceProvider.GetRequiredService<Cycle1DbContext>();
                databaseContext.Database.EnsureDeleted();
                databaseContext.Database.EnsureCreated();
                databaseContext.AjouterDonnees();

                SharedDbContext sharedDatabaseContext = serviceScope.ServiceProvider.GetRequiredService<SharedDbContext>();
                sharedDatabaseContext.Database.EnsureDeleted();
                sharedDatabaseContext.Database.EnsureCreated();
                sharedDatabaseContext.AjouterDonnees();
            }

            return app;
        }
    }
}
