using MiniUrl.Application.DTO;
using MiniUrl.Application.Exceptions;
using MiniUrl.Application.Requests;
using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.Strategies;

internal sealed class PermanentLifeTimeStrategy : IShorteningStrategy
{
    private readonly IUrlRepository _repository;
    private readonly IClock _clock;

    public PermanentLifeTimeStrategy(IUrlRepository repository, IClock clock)
    {
        _repository = repository;
        _clock = clock;
    }
    
    public async Task<ShortenedUrlDto> ShortenUrl(ShortenUrlRequest request)
    {
        if (await _repository.AnyAsync(request.CustomCode))
        {
            throw new CustomCodeAlreadyExistsException();
        }

        var now = _clock.Now();
        var shortUrl = $"{request.Schema}://{request.Host}/{request.CustomCode}";

        var shortenedUrl = new ShortenedUrl(request.Url, shortUrl, request.CustomCode, now, DateTime.MaxValue);

        await _repository.AddAsync(shortenedUrl);

        return new ShortenedUrlDto(shortUrl, request.Url);
    }
}