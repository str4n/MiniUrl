using FluentAssertions;
using MiniUrl.Application.ShortenedUrls.Services;
using MiniUrl.Domain.ShortenedUrls.Repositories;
using MiniUrl.Infrastructure.EF.Repositories;
using MiniUrl.Infrastructure.Time;
using MiniUrl.Tests.Unit.Helpers.Clock;
using MiniUrl.Tests.Unit.Helpers.Repositories;
using Xunit;

namespace MiniUrl.Tests.Unit.Strategies;

public abstract class ShorteningStrategyTests
{
    protected readonly IUrlRepository Repository;
    protected readonly IClock Clock;
    protected readonly IUrlCodeGenerator CodeGenerator;

    public ShorteningStrategyTests()
    {
        var clock = new TestClock();
        var repository = new InMemoryUrlRepository(clock);
        CodeGenerator = new UrlCodeGenerator(repository);
        Repository = repository;
        Clock = clock;
    }
}