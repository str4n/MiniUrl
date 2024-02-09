using FluentAssertions;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Strategies;
using MiniUrl.Domain.Url;
using Xunit;

namespace MiniUrl.Tests.Unit.Strategies;

public class PermanentLifeTimeNoCustomCodeStrategyTests : ShorteningStrategyTests
{
    [Fact]
    public async Task Given_Valid_Request_Strategy_Should_Shorten_Url_In_Proper_Way()
    {
        const string url = "https://www.youtube.com/";
        const string schema = "https";
        const string host = "localhost:9990";
        
        var request = new ShortenUrlRequest(schema, host, 
            url, null, default);
        
        var result = await _shorteningStrategy.ShortenUrl(request);
        
        var code = result.ShortUrl.Replace($"{schema}://{host}/", string.Empty);
        var expectedShortUrl = (Url)$"{schema}://{host}/{code}";
        
        result.LongUrl.Should().Be(url);
        result.ShortUrl.Should().Be(expectedShortUrl);

        var shortenedUrl = await  Repository.GetAsync(code);

        shortenedUrl.Code.Should().Be((Code)code);
        shortenedUrl.ShortUrl.Should().Be(expectedShortUrl);
        shortenedUrl.LongUrl.Should().Be((Url)url);
        shortenedUrl.CreatedAt.Should().Be(Clock.Now());
        shortenedUrl.Expiry.Should().Be(Clock.MaxValue());
    }
    
    
    private readonly IShorteningStrategy _shorteningStrategy;
    
    public PermanentLifeTimeNoCustomCodeStrategyTests()
    {
        _shorteningStrategy = new PermanentLifeTimeNoCustomCodeStrategy(Repository, Clock, CodeGenerator);
    }
}