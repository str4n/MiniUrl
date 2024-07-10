using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Application.Abstractions;
using MiniUrl.Application.Abstractions.Commands;
using MiniUrl.Application.Abstractions.Queries;
using MiniUrl.Application.Dispatchers;

namespace MiniUrl.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddSingleton<ICommandDispatcher, CommandDispatcher>()
            .AddSingleton<IQueryDispatcher, QueryDispatcher>()
            .AddSingleton<IDispatcher, Dispatcher>();

        services
            .Scan(x => x.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        services
            .Scan(x => x.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        
        return services;
    }
}