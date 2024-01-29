using MiniUrl.Infrastructure.Exceptions;

namespace MiniUrl.Application.Exceptions;

internal sealed class InvalidUrlException : ApiException
{
    public InvalidUrlException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}