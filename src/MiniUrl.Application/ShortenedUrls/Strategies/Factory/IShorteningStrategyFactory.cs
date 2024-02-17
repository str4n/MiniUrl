using MiniUrl.Application.ShortenedUrls.Requests;

namespace MiniUrl.Application.ShortenedUrls.Strategies.Factory;

internal interface IShorteningStrategyFactory
{
    IShorteningStrategy GetStrategy(ShortenUrlRequest request);
}