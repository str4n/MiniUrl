using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Application.Strategies.Factory;

namespace MiniUrl.Application.Strategies;

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