using A3.Lea.Cycle1.WebApi;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(AllowAllOriginsInDev);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
