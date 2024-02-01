using MiniUrl.Domain.Exceptions;

namespace MiniUrl.Application.Exceptions;

internal sealed class RedirectionNotFoundException : ApiException
{
    public RedirectionNotFoundException() : base("Redirection not found", ExceptionCategory.NotFound)
    {
    }
}