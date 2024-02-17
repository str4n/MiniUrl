using MiniUrl.Domain.Users.Exceptions;

namespace MiniUrl.Domain.Users.User;

public sealed record Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidPasswordSyntaxException("Password cannot be empty.");
        }

        Value = value;
    }

    public static implicit operator string(Password password) => password.Value;
    public static implicit operator Password(string password) => new(password);
}