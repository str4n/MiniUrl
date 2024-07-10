using MiniUrl.Application.Abstractions.Commands;
using MiniUrl.Application.Abstractions.Queries;

namespace MiniUrl.Application.Abstractions;

public interface IDispatcher
{
    Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query);
}