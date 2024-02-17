using FluentAssertions;
using MiniUrl.Application.Exceptions;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Strategies;
using MiniUrl.Domain.ShortenedUrls.Url;
using Xunit;

namespace MiniUrl.Tests.Unit.Strategies;

public class CustomCodePermanentLifeTimeStrategyTests : ShorteningStrategyTests
{
    [Fact]
    public async Task Given_Valid_Request_Strategy_Should_Shorten_Url_In_Proper_Way()
    {
        const string url = "https://www.youtube.com/";
        const string schema = "https";
        const string host = "localhost:9990";
        const string code = "youtub";
        
        var request = new ShortenUrlRequest(schema, host, 
            url, code, default);

        var result = await _shorteningStrategy.ShortenUrl(request);
        
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
    
    [Fact]
    public async Task Given_Request_With_Code_Already_In_Use_Strategy_Should_Shorten_Url_In_Proper_Way()
    {
        const string url = "https://www.youtube.com/";
        const string schema = "https";
        const string host = "localhost:9990";
        const string code = "youtube";
        
        var request = new ShortenUrlRequest(schema, host, 
            url, code, default);

        var act = () => _shorteningStrategy.ShortenUrl(request);
        
        await act.Should().ThrowAsync<CustomCodeAlreadyExistsException>();
    }
    
    private readonly IShorteningStrategy _shorteningStrategy;
    
    public CustomCodePermanentLifeTimeStrategyTests()
    {
        _shorteningStrategy = new CustomCodePermanentLifeTimeStrategy(Repository, Clock);
    }
}