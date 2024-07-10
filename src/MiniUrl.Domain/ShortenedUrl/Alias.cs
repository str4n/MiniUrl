using MiniUrl.Domain.ShortenedUrl.Exceptions;

namespace MiniUrl.Domain.ShortenedUrl;

public sealed record Alias
{
    public string Value { get; }
    
    public Alias(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidUrlAliasException("Alias cannot be empty.");
        }

        if (value.Length < UrlAliasSettings.MinimalUrlAliasLength)
        {
            throw new InvalidUrlAliasException("Alias must contain at least 4 characters.");
        }
        
        if (value.Length > UrlAliasSettings.MaximalUrlAliasLength)
        {
            throw new InvalidUrlAliasException("Alias must contain less than 10 characters.");
        }
        
        foreach (var character in value)
        {
            if (!UrlAliasSettings.AvailableCharacters.ToCharArray().Contains(character))
            {
                throw new InvalidUrlAliasException("Alias can contain only letters or numbers.");
            }
        }
        

        Value = value;
    }
    
    public static implicit operator string(Alias alias) => alias.Value;
    public static implicit operator Alias(string alias) => new(alias);
}