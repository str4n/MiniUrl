using MiniUrl.Application.DTO;
using MiniUrl.Application.Exceptions;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Strategies;
using MiniUrl.Application.Strategies.Factory;
using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.Services;

internal sealed class UrlService : IUrlService
{
    private readonly IShorteningStrategyFactory _factory;
    private readonly IUrlRepository _repository;

    public UrlService(IShorteningStrategyFactory factory, IUrlRepository repository)
    {
        _factory = factory;
        _repository = repository;
    }
    
    public async Task<ShortenedUrlDto> Shorten(ShortenUrlRequest request)
    {
        var strategy = _factory.GetStrategy(request);

        var result = await strategy.ShortenUrl(request);

        return result;
    }

    public async Task<ShortenedUrlDto> GetUrl(Code code)
    {
        var result = await _repository.GetAsync(code);

        if (result is null)
        {
            throw new RedirectionNotFoundException();
        }

        return new ShortenedUrlDto(result.ShortUrl, result.LongUrl);
    }
}