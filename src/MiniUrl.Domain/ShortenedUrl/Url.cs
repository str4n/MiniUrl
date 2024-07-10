using MiniUrl.Domain.ShortenedUrl.Exceptions;

namespace MiniUrl.Domain.ShortenedUrl;

public sealed record Url
{
    public string Value { get; }

    public Url(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidUrlException("Url cannot be empty.");
        }

        if (!Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out var uri))
        {
            throw new InvalidUrlException("Invalid url format.");
        }

        Value = value;
    }
    
    public static implicit operator string(Url url) => url.Value;
    public static implicit operator Url(string url) => new(url);
}