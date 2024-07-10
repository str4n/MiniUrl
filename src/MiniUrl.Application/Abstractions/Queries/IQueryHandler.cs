namespace MiniUrl.Application.Abstractions.Queries;

internal interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}