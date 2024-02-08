using FluentAssertions;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Services;
using MiniUrl.Application.Strategies;
using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;
using MiniUrl.Infrastructure.EF.Repositories;
using MiniUrl.Infrastructure.Time;
using MiniUrl.Tests.Unit.Helpers.Clock;
using MiniUrl.Tests.Unit.Helpers.Repositories;
using Xunit;

namespace MiniUrl.Tests.Unit.Strategies;

public class ShorteningStrategiesTests
{
    [Fact]
    public async Task No_Custom_Code_Strategy_Should_Shorten_Url_In_Proper_Way()
    {
        const string url = "https://www.youtube.com/";
        const string schema = "https";
        const string host = "localhost:9990";
        const int lifeTime = 12;
        
        var request = new ShortenUrlRequest(schema, host, 
            url, null, lifeTime);

        var result = await _noCustomCodeStrategy.ShortenUrl(request);

        result.LongUrl.Should().Be(url);
        result.ShortUrl.Should().NotBeNull();

        var code = result.ShortUrl.Replace($"{schema}://{host}/", string.Empty);

        var shortenedUrl = await  _repository.GetAsync(code);

        shortenedUrl.Code.Should().Be((Code)code);
        shortenedUrl.ShortUrl.Should().Be((Url)$"{schema}://{host}/{code}");
        shortenedUrl.LongUrl.Should().Be((Url)url);
        shortenedUrl.CreatedAt.Should().Be(_clock.Now());
        shortenedUrl.Expiry.Should().Be(_clock.Now().AddHours(lifeTime));
    }

    
    private readonly IShorteningStrategy _noCustomCodeStrategy;
    private readonly IUrlRepository _repository;
    private readonly IClock _clock;

    public ShorteningStrategiesTests()
    {
        var clock = new TestClock();
        var repository = new InMemoryUrlRepository();
        var codeGenerator = new UrlCodeGenerator(repository);
        _noCustomCodeStrategy = new NoCustomCodeStrategy(repository, clock, codeGenerator);
        _repository = repository;
        _clock = clock;
    }
}