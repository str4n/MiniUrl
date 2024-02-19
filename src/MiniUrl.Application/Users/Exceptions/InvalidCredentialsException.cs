using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Application.Users.Exceptions;

internal sealed class InvalidCredentialsException : ApiException
{
    public InvalidCredentialsException() : base("Invalid username or password.", ExceptionCategory.BadRequest)
    {
    }
}