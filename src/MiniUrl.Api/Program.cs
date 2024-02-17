using MiniUrl.Api.Endpoints;
using MiniUrl.Application;
using MiniUrl.Application.ShortenedUrls;
using MiniUrl.Domain;
using MiniUrl.Domain.ShortenedUrls;
using MiniUrl.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddDomain()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapHomeEndpoints();
app.MapUrlEndpoints();
app.MapUserEndpoints();

app.UseInfrastructure();

app.Run();