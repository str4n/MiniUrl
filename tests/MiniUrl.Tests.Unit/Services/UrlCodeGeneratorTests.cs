using FluentAssertions;
using MiniUrl.Application.Services;
using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;
using MiniUrl.Tests.Unit.Helpers.Clock;
using MiniUrl.Tests.Unit.Helpers.Repositories;
using Xunit;

namespace MiniUrl.Tests.Unit.Services;

public class UrlCodeGeneratorTests
{
    [Fact]
    public async Task Generate_Method_Should_Return_Proper_Url_Code()
    {
        var code = await _codeGenerator.Generate();

        code.Value.Should().HaveLength(7);
        code.Value.Select(x => x.Should().BeOneOf(ShortUrlSettings.AvailableCharacters.ToCharArray()));
    }

    private readonly IUrlCodeGenerator _codeGenerator;

    public UrlCodeGeneratorTests()
    {
        var clock = new TestClock();
        IUrlRepository urlRepository = new InMemoryUrlRepository(clock);
        _codeGenerator = new UrlCodeGenerator(urlRepository);
    }
}