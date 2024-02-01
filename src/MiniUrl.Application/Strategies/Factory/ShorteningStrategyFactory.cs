using MiniUrl.Application.Requests;

namespace MiniUrl.Application.Strategies.Factory;

internal sealed class ShorteningStrategyFactory : IShorteningStrategyFactory
{
    private readonly IEnumerable<IShorteningStrategy> _strategies;

    public ShorteningStrategyFactory(IEnumerable<IShorteningStrategy> strategies)
    {
        _strategies = strategies;
    }
    
    public IShorteningStrategy GetStrategy(ShortenUrlRequest request)
    {
        if (request.LifeTime is 0 && request.CustomCode is null)
        {
            return _strategies.SingleOrDefault(x => x is NoLifeTimeNoCustomCodeStrategy);
        }

        if (request.LifeTime is 0)
        {
            return _strategies.SingleOrDefault(x => x is NoLifeTimeStrategy);
        }

        if (request.CustomCode is null)
        {
            return _strategies.SingleOrDefault(x => x is NoCustomCodeStrategy);
        }

        return _strategies.SingleOrDefault(x => x is DefaultStrategy);
    }
}