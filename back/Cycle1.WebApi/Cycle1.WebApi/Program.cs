using A3.Lea.Cycle1.WebApi.Extensions;
using Hellang.Middleware.ProblemDetails.Mvc;

var allowAllOriginsInDev = "_allowAllOriginsInDev";
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

// Add services to the container.
builder.Services.AddCycle1Services();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddProblemDetailsConventions();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(name: allowAllOriginsInDev, builder => builder.WithOrigins("*")));

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
    // Quand une exception non gérée par le code est trappée par le framework AspNetCore, il appel le controller derriere la route passé en paramètre.
    // Cela permet d'ajouter du comportement.
    app.UseExceptionHandler("/erreur");
    app.UseHsts();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
