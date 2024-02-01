using MiniUrl.Application.Requests;

namespace MiniUrl.Application.Strategies.Factory;

internal interface IShorteningStrategyFactory
{
    IShorteningStrategy GetStrategy(ShortenUrlRequest request);
}