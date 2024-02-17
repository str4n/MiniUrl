using MiniUrl.Domain.ShortenedUrls.Repositories;
using MiniUrl.Domain.ShortenedUrls.Url;

namespace MiniUrl.Application.Services;

internal sealed class UrlCodeGenerator : IUrlCodeGenerator
{
    private readonly IUrlRepository _repository;
    private readonly Random _random = new();

    public UrlCodeGenerator(IUrlRepository repository)
    {
        _repository = repository;
    }
    public async Task<Code> Generate()
    {
        var codeChars = new char[ShortUrlSettings.GeneratedUrlLength];
        int maxValue = ShortUrlSettings.AvailableCharacters.Length;

        while (true)
        {
            for (var i = 0; i < ShortUrlSettings.GeneratedUrlLength; i++)
            {
                var randomIndex = _random.Next(maxValue);

                codeChars[i] = ShortUrlSettings.AvailableCharacters[randomIndex];
            }

            var code = new string(codeChars);

            if (!await _repository.AnyAsync(code))
            {
                return code;
            }
        }
    }
}