using A3.Lea.Cycle1.WebApi;
using A3.Lea.Cycle1.WebApi.MySql;
using Microsoft.EntityFrameworkCore;

var AllowAllOriginsInDev = "_allowAllOriginsInDev";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCycle1Service();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration du cors pour le contexte dev
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAllOriginsInDev,
                      builder =>
                      {
                          builder.WithOrigins("*");
                      });
});

// Configuration de EF sur MySQL
string connectionString = builder.Configuration.GetConnectionString("MySQLConnectionString");
//      MigrationAssembly : https://docs.microsoft.com/fr-fr/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
//      => Permet de simplifier la commande de génération des migrations lorsque le DbContext n'est pas dans l'assembly de démarrage
builder.Services.AddDbContext<DatabaseContext>(options =>
   options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("A3.Lea.Cycle1.WebApi"))
   );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var serviceScope = app.Services.CreateScope())
    {
        DatabaseContext databaseContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
        databaseContext.Database.EnsureDeleted();
        databaseContext.Database.EnsureCreated();
        databaseContext.AjouterDonnees();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(AllowAllOriginsInDev);
}

// Pour la prise en charge de l'index.html Angular dans le sous-répertoire wwwroot
app.UseDefaultFiles();

// Pour la prise en charge des fichiers static Angular
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = context =>
    {
        if (context.File.Name.Equals("index.html", StringComparison.Ordinal))
        {
            context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
            context.Context.Response.Headers.Add("Expires", "-1");
        }
    }
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
