using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Application.ShortenedUrls.Strategies.Factory;

namespace MiniUrl.Application.ShortenedUrls.Strategies;

internal static class Extensions
{
    public static IServiceCollection AddStrategies(this IServiceCollection services)
    {
        services.AddScoped<IShorteningStrategyFactory, ShorteningStrategyFactory>();

        services
            .AddScoped<IShorteningStrategy, PermanentLifeTimeStrategy>()
            .AddScoped<IShorteningStrategy, CustomCodePermanentLifeTimeStrategy>()
            .AddScoped<IShorteningStrategy, DefaultStrategy>()
            .AddScoped<IShorteningStrategy, CustomCodeStrategy>();

        return services;
    }
}