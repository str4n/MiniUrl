using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Application.Users.Exceptions;

internal sealed class AccountNotActiveException : ApiException
{
    public AccountNotActiveException() : base("Account is not active.", ExceptionCategory.NotFound)
    {
    }
}