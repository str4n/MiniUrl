using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Domain.ShortenedUrls.Url;

public sealed record Code
{
    public string Value { get; }

    public Code(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidCodeException("Url code cannot be empty.");
        }

        if (value.Length is <= ShortUrlSettings.MinimalUrlLength or >= ShortUrlSettings.MaximalUrlLength)
        {
            throw new InvalidCodeException($"Url code length must be between: [{ShortUrlSettings.MinimalUrlLength}, {ShortUrlSettings.MaximalUrlLength}]");
        }

        foreach (var character in value)
        {
            if (!ShortUrlSettings.AvailableCharacters.ToCharArray().Contains(character))
            {
                throw new InvalidCodeException("Code must contain only numbers or letters");
            }
        }

        Value = value;
    }

    public static implicit operator string(Code code) => code.Value;
    public static implicit operator Code(string code) => new(code);
}