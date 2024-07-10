namespace MiniUrl.Application.Abstractions.Commands;

internal interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command);
}