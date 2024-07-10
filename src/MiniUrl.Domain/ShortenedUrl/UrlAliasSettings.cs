namespace MiniUrl.Domain.ShortenedUrl;

public static class UrlAliasSettings
{
    public const int MinimalUrlAliasLength = 4;
    public const int MaximalUrlAliasLength = 10;
    public const int GeneratedUrlAliasLength = 6;
    public const string AvailableCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
}