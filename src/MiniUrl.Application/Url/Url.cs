using MiniUrl.Application.Exceptions;

namespace MiniUrl.Application.Url;

public sealed record Url
{
    public string Value { get; }

    public Url(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidUrlException("Url cannot be empty.");
        }

        if (!value.StartsWith(UrlSettings.WebSiteUrl))
        {
            throw new InvalidUrlException($"Url must start with: {UrlSettings.WebSiteUrl}");
        }

        Value = value;
    }

    public static implicit operator string(Url url) => url.Value;
    public static implicit operator Url(string url) => new(url);
}