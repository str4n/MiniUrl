using MiniUrl.Application.DTO;
using MiniUrl.Application.Requests;

namespace MiniUrl.Application.Strategies;

internal sealed class NoLifeTimeNoCustomCodeStrategy : IShorteningStrategy
{
    public Task<ShortenedUrlDto> ShortenUrl(ShortenUrlRequest request)
    {
        throw new NotImplementedException();
    }
}