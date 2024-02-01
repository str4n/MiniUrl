using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Application.Services;
using MiniUrl.Application.Strategies;

namespace MiniUrl.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUrlService, UrlService>();
        services.AddScoped<IUrlCodeGenerator, UrlCodeGenerator>();

        services.AddStrategies();
        
        return services;
    }
}