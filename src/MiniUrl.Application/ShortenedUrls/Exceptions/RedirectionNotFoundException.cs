using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Application.ShortenedUrls.Exceptions;

internal sealed class RedirectionNotFoundException : ApiException
{
    public RedirectionNotFoundException() : base("Redirection not found", ExceptionCategory.NotFound)
    {
    }
}