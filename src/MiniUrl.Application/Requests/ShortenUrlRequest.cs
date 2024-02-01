namespace MiniUrl.Application.Requests;

public sealed record ShortenUrlRequest(string Scheme, string Host, string Url, string CustomCode, int LifeTime); // lifeTime in hours