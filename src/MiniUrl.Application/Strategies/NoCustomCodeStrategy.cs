using MiniUrl.Application.DTO;
using MiniUrl.Application.Requests;

namespace MiniUrl.Application.Strategies;

internal sealed class NoCustomCodeStrategy : IShorteningStrategy
{
    public Task<ShortenedUrlDto> ShortenUrl(ShortenUrlRequest request)
    {
        throw new NotImplementedException();
    }
}