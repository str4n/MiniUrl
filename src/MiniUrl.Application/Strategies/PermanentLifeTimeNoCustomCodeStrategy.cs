using MiniUrl.Application.DTO;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Services;
using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.Strategies;

internal sealed class PermanentLifeTimeNoCustomCodeStrategy : IShorteningStrategy
{
    private readonly IUrlRepository _repository;
    private readonly IClock _clock;
    private readonly IUrlCodeGenerator _codeGenerator;

    public PermanentLifeTimeNoCustomCodeStrategy(IUrlRepository repository, IClock clock, IUrlCodeGenerator codeGenerator)
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

        var shortenedUrl = new ShortenedUrl(request.Url, shortUrl, code, now, DateTime.MaxValue);

        await _repository.AddAsync(shortenedUrl);

        return new ShortenedUrlDto(shortUrl, request.Url);
    }
}