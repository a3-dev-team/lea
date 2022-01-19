<<<<<<< HEAD
using A3.Lea.Cycle1.WebApi.Extensions;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
=======
using A3.Lea.Cycle1.WebApi;
using A3.Lea.Cycle1.WebApi.MySql;
using Microsoft.EntityFrameworkCore;
>>>>>>> 0b2de52 (feat : Bdd ConnectionString)

var allowAllOriginsInDev = "_allowAllOriginsInDev";
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

// Par défaut, tous les controllers nécessite une authentification
builder.Services.AddControllers(options => options.Filters.Add(new AuthorizeFilter()));

<<<<<<< HEAD
builder.Services.AddCycle1Authentication(builder.Configuration)
                .AddSharedServices()
                .AddCycle1Services()
                .AddProblemDetails()
                .AddProblemDetailsConventions()
                .AddEndpointsApiExplorer() // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                .AddSwagger()
                .AddCors(options => options.AddPolicy(name: allowAllOriginsInDev, builder => builder.WithOrigins("*")));
=======
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
>>>>>>> 0b2de52 (feat : Bdd ConnectionString)

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
<<<<<<< HEAD
    app.UseDeveloperExceptionPage()
       .UseSwagger()
       .UseSwaggerUI()
       .UseCors(allowAllOriginsInDev);
}
else
{
    app.UseProblemDetails()
       // Activation du middleware de gestion des exceptions :
       // Quand une exception non gérée par le code est trapp�e par le framework AspNetCore, il appel le controller derriere la route passé en paramétre.
       // Cela permet d'ajouter du comportement.
       .UseExceptionHandler("/error")
       .UseHsts();
=======
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
>>>>>>> 867e9ab (feat : Prise en charge des migrations EF.)
}

app.UseDefaultFiles()                      // Pour la prise en charge de l'index.html Angular dans le sous-répertoire wwwroot
   .UseStaticFiles(new StaticFileOptions() // Pour la prise en charge des fichiers static Angular
   {
       OnPrepareResponse = context =>
       {
           if (context.File.Name.Equals("index.html", StringComparison.Ordinal))
           {
               context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
               context.Context.Response.Headers.Add("Expires", "-1");
           }
       }
   })
   .UseHttpsRedirection()
   .UseRouting()
   .UseAuthentication()
   .UseAuthorization();

app.MapControllers();
app.Run();
