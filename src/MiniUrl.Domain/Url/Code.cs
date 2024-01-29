using MiniUrl.Domain.Exceptions;

namespace MiniUrl.Domain.Url;

public sealed record Code
{
    public string Value { get; }

    public Code(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidCodeException("Url code cannot be empty.");
        }

        if (value.Length != ShortUrlSettings.Length)
        {
            throw new InvalidCodeException($"Url code length must equal: {ShortUrlSettings.Length}");
        }

        Value = value;
    }

    public static implicit operator string(Code code) => code.Value;
    public static implicit operator Code(string code) => new(code);
}