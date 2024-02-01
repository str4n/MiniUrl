using MiniUrl.Application.DTO;
using MiniUrl.Application.Requests;

namespace MiniUrl.Application.Strategies;

internal interface IShorteningStrategy
{
    Task<ShortenedUrlDto> ShortenUrl(ShortenUrlRequest request);
}