using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Application.Abstractions.Queries;

namespace MiniUrl.Application.Dispatchers;

internal sealed class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query)
    {
        using var scope = _serviceProvider.CreateScope();

        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        var result = await (Task<TResult>)handlerType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))?
            .Invoke(handler, new[] { query });

        return result;
    }
}