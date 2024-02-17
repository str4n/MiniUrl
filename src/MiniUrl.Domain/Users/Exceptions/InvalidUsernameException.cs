using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Domain.Users.Exceptions;

internal sealed class InvalidUsernameException : ApiException
{
    public InvalidUsernameException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}