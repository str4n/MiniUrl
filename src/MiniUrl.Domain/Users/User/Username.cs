using MiniUrl.Domain.Users.Exceptions;

namespace MiniUrl.Domain.Users.User;

public sealed record Username
{
    public string Value { get; }

    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidUsernameException("Username cannot be empty.");
        }

        if (value.Length is < 3 or > 30)
        {
            throw new InvalidUsernameException("Username length must be between 3-30 symbols.");
        }

        Value = value;
    }
    
    public static implicit operator string(Username username) => username.Value;
    public static implicit operator Username(string username) => new(username);
}