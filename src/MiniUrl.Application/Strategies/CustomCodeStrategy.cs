using MiniUrl.Application.DTO;
using MiniUrl.Application.Exceptions;
using MiniUrl.Application.Requests;
using MiniUrl.Domain.ShortenedUrls.Repositories;
using MiniUrl.Domain.ShortenedUrls.Url;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.Strategies;

internal sealed class CustomCodeStrategy : IShorteningStrategy
{
    private readonly IUrlRepository _repository;
    private readonly IClock _clock;

    public CustomCodeStrategy(IUrlRepository repository, IClock clock)
    {
        _repository = repository;
        _clock = clock;
    }
    
    public async Task<ShortenedUrlDto> ShortenUrl(ShortenUrlRequest request)
    {
        if (request.LifeTime < 12)
        {
            throw new InvalidUrlLifeTimeException("The url life time cannot be less than 12 hours.");
        }
        
        if (await _repository.AnyAsync(request.CustomCode))
        {
            throw new CustomCodeAlreadyExistsException();
        }

        var now = _clock.Now();
        var expiry = now.AddHours(request.LifeTime);
        var shortUrl = $"{request.Schema}://{request.Host}/{request.CustomCode}";

        var shortenedUrl = new ShortenedUrl(request.Url, shortUrl, request.CustomCode, now, expiry);

        await _repository.AddAsync(shortenedUrl);

        return new ShortenedUrlDto(shortUrl, request.Url);
    }
}