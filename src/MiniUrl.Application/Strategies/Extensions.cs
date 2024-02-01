using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Application.Strategies.Factory;

namespace MiniUrl.Application.Strategies;

internal static class Extensions
{
    public static IServiceCollection AddStrategies(this IServiceCollection services)
    {
        services.AddSingleton<IShorteningStrategyFactory, ShorteningStrategyFactory>();

        services
            .AddSingleton<IShorteningStrategy, NoLifeTimeNoCustomCodeStrategy>()
            .AddSingleton<IShorteningStrategy, NoLifeTimeStrategy>()
            .AddSingleton<IShorteningStrategy, NoCustomCodeStrategy>()
            .AddSingleton<IShorteningStrategy, DefaultStrategy>();

        return services;
    }
}