using DapperPractice.Logic.Services;
using DapperPractice.Persistence;
using DapperPractice.Persistence.Extensions;
using DapperPractice.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddScoped<ProductsService>();
services.AddPersistence(builder.Configuration);
services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();