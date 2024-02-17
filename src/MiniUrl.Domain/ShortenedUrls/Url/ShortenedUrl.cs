namespace MiniUrl.Domain.ShortenedUrls.Url;

public sealed class ShortenedUrl
{
    public Guid Id { get; }
    public Url LongUrl { get; private set; }
    public Url ShortUrl { get; private set; }
    public Code Code { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime Expiry { get; }

    public ShortenedUrl(Url longUrl, Url shortUrl, Code code, DateTime createdAt, DateTime expiry,Guid id = default)
    {
        Id = id != Guid.Empty ? id : Guid.NewGuid();
        LongUrl = longUrl;
        ShortUrl = shortUrl;
        Code = code;
        CreatedAt = createdAt;
        Expiry = expiry;
    }

    private ShortenedUrl()
    {
    }
}