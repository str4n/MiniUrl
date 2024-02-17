using MiniUrl.Application.DTO;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Services;
using MiniUrl.Domain.ShortenedUrls.Repositories;
using MiniUrl.Domain.ShortenedUrls.Url;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.Strategies;

internal sealed class PermanentLifeTimeStrategy : IShorteningStrategy
{
    private readonly IUrlRepository _repository;
    private readonly IClock _clock;
    private readonly IUrlCodeGenerator _codeGenerator;

    public PermanentLifeTimeStrategy(IUrlRepository repository, IClock clock, IUrlCodeGenerator codeGenerator)
    {
        _repository = repository;
        _clock = clock;
        _codeGenerator = codeGenerator;
    }
    
    public async Task<ShortenedUrlDto> ShortenUrl(ShortenUrlRequest request)
    {
        var code = (await _codeGenerator.Generate()).Value;
        var now = _clock.Now();
        var shortUrl = $"{request.Schema}://{request.Host}/{code}";

        var shortenedUrl = new ShortenedUrl(request.Url, shortUrl, code, now, _clock.MaxValue());

        await _repository.AddAsync(shortenedUrl);

        return new ShortenedUrlDto(shortUrl, request.Url);
    }
}