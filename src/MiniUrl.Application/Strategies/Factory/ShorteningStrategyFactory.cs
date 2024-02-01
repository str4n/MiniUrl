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
        if (request.LifeTime is default(int) && request.CustomCode is null)
        {
            return _strategies.SingleOrDefault(x => x is PermanentLifeTimeNoCustomCodeStrategy);
        }

        if (request.LifeTime is default(int))
        {
            return _strategies.SingleOrDefault(x => x is PermanentLifeTimeStrategy);
        }

        if (request.CustomCode is null)
        {
            return _strategies.SingleOrDefault(x => x is NoCustomCodeStrategy);
        }

        return _strategies.SingleOrDefault(x => x is DefaultStrategy);
    }
}