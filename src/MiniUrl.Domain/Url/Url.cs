using MiniUrl.Domain.Exceptions;

namespace MiniUrl.Domain.Url;

public sealed record Url
{
    public string Value { get; }

    public Url(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidUrlException("Url cannot be empty.");
        }

        Value = value;
    }

    public static implicit operator string(Url url) => url.Value;
    public static implicit operator Url(string url) => new(url);
}