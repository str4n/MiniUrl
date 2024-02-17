namespace MiniUrl.Application.ShortenedUrls.Requests;

public sealed record ShortenUrlRequest(string Schema, string Host, string Url, string CustomCode, int LifeTime); // lifeTime in hours