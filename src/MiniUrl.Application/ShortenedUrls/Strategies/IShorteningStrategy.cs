using MiniUrl.Application.ShortenedUrls.DTO;
using MiniUrl.Application.ShortenedUrls.Requests;

namespace MiniUrl.Application.ShortenedUrls.Strategies;

internal interface IShorteningStrategy
{
    Task<ShortenedUrlDto> ShortenUrl(ShortenUrlRequest request);
}