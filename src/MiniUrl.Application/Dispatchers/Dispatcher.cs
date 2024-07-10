using MiniUrl.Application.Abstractions;
using MiniUrl.Application.Abstractions.Commands;
using MiniUrl.Application.Abstractions.Queries;

namespace MiniUrl.Application.Dispatchers;

internal sealed class Dispatcher : IDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        => await _commandDispatcher.DispatchAsync(command);

    public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query)
        => await _queryDispatcher.DispatchAsync(query);
}