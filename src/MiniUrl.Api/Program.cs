using MiniUrl.Api.Endpoints;
using MiniUrl.Application;
using MiniUrl.Domain;
using MiniUrl.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddDomain()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapHomeEndpoints();
app.MapUrlEndpoints();

app.UseInfrastructure();

app.Run();