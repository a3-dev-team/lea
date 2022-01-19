using A3.Lea.Cycle1.WebApi.Extensions;
using Hellang.Middleware.ProblemDetails.Mvc;

var allowAllOriginsInDev = "_allowAllOriginsInDev";
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

// Add services to the container.
builder.Services.AddCycle1Services();
builder.Services.AddProblemDetails();
//builder.Services.AddControllers(options => options.Filters.Add(new AuthorizeFilter()));
builder.Services.AddProblemDetailsConventions();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(name: allowAllOriginsInDev, builder => builder.WithOrigins("*")));
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(allowAllOriginsInDev);
}
else
{
    // Activiation du middleware de gestion des ProblemDetails
    app.UseProblemDetails();
    // Activation du middleware de gestion des exceptions :
    // Quand une exception non gérée par le code est trapp�e par le framework AspNetCore, il appel le controller derriere la route passé en paramétre.
    // Cela permet d'ajouter du comportement.
    app.UseExceptionHandler("/error");
    app.UseHsts();
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
app.UseRouting();
//app.UseAuthentication()
app.UseAuthorization();
app.MapControllers();
app.Run();
