namespace MiniUrl.Domain.ShortenedUrl;

public sealed class ShortenedUrl
{
    public Guid Id { get; }
    public Url LongUrl { get; private set; } 
    public Url ShortUrl { get; private set; } 
    public Alias Alias { get; private set; }
    public DateTime CreatedAt { get; }

    public ShortenedUrl(Guid id, Url longUrl, Url shortUrl, Alias alias, DateTime createdAt)
    {
        Id = id;
        LongUrl = longUrl;
        ShortUrl = shortUrl;
        Alias = alias;
        CreatedAt = createdAt;
    }
    
    public ShortenedUrl(Url longUrl, Url shortUrl, Alias alias, DateTime createdAt) 
        : this(Guid.NewGuid(), longUrl, shortUrl, alias, createdAt)
    {
    }
}