using FluentAssertions;
using MiniUrl.Application.Exceptions;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Strategies;
using MiniUrl.Domain.Url;
using Xunit;

namespace MiniUrl.Tests.Unit.Strategies;

public class DefaultStrategyTests : ShorteningStrategyTests
{
    [Fact]
    public async Task Given_Valid_Request_Strategy_Should_Shorten_Url_In_Proper_Way()
    {
        const string url = "https://www.youtube.com/";
        const string schema = "https";
        const string host = "localhost:9990";
        const string code = "youtub";
        const int lifeTime = 12;
        
        var request = new ShortenUrlRequest(schema, host, 
            url, code, lifeTime);

        var result = await _shorteningStrategy.ShortenUrl(request);
        
        var expectedShortUrl = (Url)$"{schema}://{host}/{code}";
        
        result.LongUrl.Should().Be(url);
        result.ShortUrl.Should().Be(expectedShortUrl);

        var shortenedUrl = await  Repository.GetAsync(code);

        shortenedUrl.Code.Should().Be((Code)code);
        shortenedUrl.ShortUrl.Should().Be(expectedShortUrl);
        shortenedUrl.LongUrl.Should().Be((Url)url);
        shortenedUrl.CreatedAt.Should().Be(Clock.Now());
        shortenedUrl.Expiry.Should().Be(Clock.Now().AddHours(lifeTime));
    }

    [Fact]
    public async Task Given_Request_With_Code_Already_In_Use_Strategy_Should_Shorten_Url_In_Proper_Way()
    {
        const string url = "https://www.youtube.com/";
        const string schema = "https";
        const string host = "localhost:9990";
        const string code = "youtube";
        const int lifeTime = 12;
        
        var request = new ShortenUrlRequest(schema, host, 
            url, code, lifeTime);

        var act = () => _shorteningStrategy.ShortenUrl(request);
        
        await act.Should().ThrowAsync<CustomCodeAlreadyExistsException>();
    }
    
    
    private readonly IShorteningStrategy _shorteningStrategy;
    
    public DefaultStrategyTests()
    {
        _shorteningStrategy = new DefaultStrategy(Repository, Clock);
    }
}