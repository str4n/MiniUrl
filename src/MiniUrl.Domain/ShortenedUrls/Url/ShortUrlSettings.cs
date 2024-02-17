namespace MiniUrl.Domain.ShortenedUrls.Url;

public static class ShortUrlSettings
{
    public const int MinimalUrlLength = 5;
    public const int MaximalUrlLength = 10;
    public const int GeneratedUrlLength = 7;
    public const string AvailableCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
}