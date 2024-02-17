using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Application.Exceptions;

internal sealed class CustomCodeAlreadyExistsException : ApiException
{
    public CustomCodeAlreadyExistsException() : base("This code is already in use.", ExceptionCategory.AlreadyExists)
    {
    }
}