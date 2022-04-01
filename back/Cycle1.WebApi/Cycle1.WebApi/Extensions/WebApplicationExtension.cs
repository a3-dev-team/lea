using A3.Lea.Cycle1.WebApi.Dal;
using A3.Shared.WebApi.Dal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication InitDB(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                SharedDbContext sharedDatabaseContext = serviceScope.ServiceProvider.GetRequiredService<SharedDbContext>();
                // if (app.Environment.IsDevelopment())
                // {
                sharedDatabaseContext.Database.EnsureDeleted();
                // }
                if (sharedDatabaseContext.Database.EnsureCreated())
                {
                    sharedDatabaseContext.AjouterDonnees();

                    Cycle1DbContext cycle1DbContext = serviceScope.ServiceProvider.GetRequiredService<Cycle1DbContext>();
                    cycle1DbContext.GetService<IRelationalDatabaseCreator>().CreateTables();
                    cycle1DbContext.AjouterDonnees();
                }
            }
            return app;
        }
    }
}
