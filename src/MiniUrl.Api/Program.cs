using MiniUrl.Application;
using MiniUrl.Domain;
using MiniUrl.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddDomain()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseInfrastructure();

app.Run();
