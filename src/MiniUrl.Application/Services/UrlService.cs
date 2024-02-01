using MiniUrl.Application.DTO;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Strategies;
using MiniUrl.Application.Strategies.Factory;
using MiniUrl.Domain.Repositories;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.Services;

internal sealed class UrlService : IUrlService
{
    private readonly IShorteningStrategyFactory _factory;

    public UrlService(IShorteningStrategyFactory factory)
    {
        _factory = factory;
    }
    
    public async Task<ShortenedUrlDto> Shorten(ShortenUrlRequest request)
    {
        var strategy = _factory.GetStrategy(request);

        var result = await strategy.ShortenUrl(request);

        return result;
    }
}