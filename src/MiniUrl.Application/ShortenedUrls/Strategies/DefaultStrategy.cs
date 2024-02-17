using MiniUrl.Application.ShortenedUrls.DTO;
using MiniUrl.Application.ShortenedUrls.Exceptions;
using MiniUrl.Application.ShortenedUrls.Requests;
using MiniUrl.Application.ShortenedUrls.Services;
using MiniUrl.Domain.ShortenedUrls.Repositories;
using MiniUrl.Domain.ShortenedUrls.Url;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.ShortenedUrls.Strategies;

internal sealed class DefaultStrategy : IShorteningStrategy
{
    private readonly IUrlRepository _repository;
    private readonly IClock _clock;
    private readonly IUrlCodeGenerator _codeGenerator;

    public DefaultStrategy(IUrlRepository repository, IClock clock, IUrlCodeGenerator codeGenerator)
    {
        _repository = repository;
        _clock = clock;
        _codeGenerator = codeGenerator;
    }
    
    public async Task<ShortenedUrlDto> ShortenUrl(ShortenUrlRequest request)
    {
        if (request.LifeTime < 12)
        {
            throw new InvalidUrlLifeTimeException("The url life time cannot be less than 12 hours.");
        }
        
        var code = (await _codeGenerator.Generate()).Value;
        var now = _clock.Now();
        var expiry = now.AddHours(request.LifeTime);
        var shortUrl = $"{request.Schema}://{request.Host}/{code}";

        var shortenedUrl = new ShortenedUrl(request.Url, shortUrl, code, now, expiry);

        await _repository.AddAsync(shortenedUrl);

        return new ShortenedUrlDto(shortUrl, request.Url);
    }
}