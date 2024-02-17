using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Application.Users.Exceptions;

internal sealed class UserAlreadyExistsException : ApiException
{
    public UserAlreadyExistsException(string message) : base(message, ExceptionCategory.AlreadyExists)
    {
    }
}