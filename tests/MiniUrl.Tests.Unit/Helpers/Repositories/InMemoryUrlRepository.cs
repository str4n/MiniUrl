using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Tests.Unit.Helpers.Repositories;

internal sealed class InMemoryUrlRepository : IUrlRepository
{
    private readonly IClock _clock;

    private static readonly List<ShortenedUrl> ShortenedUrls = new();

    public InMemoryUrlRepository(IClock clock)
    {
        _clock = clock;
        ShortenedUrls
            .Add(new ShortenedUrl("https://www.youtube.com/", "https://localhost:9990/youtube", 
                "youtube", _clock.Now(), _clock.MaxValue()));
    }

    public Task<ShortenedUrl> GetAsync(Code code)
        => Task.FromResult(ShortenedUrls.SingleOrDefault(x => x.Code == code));

    public Task AddAsync(ShortenedUrl shortenedUrl)
    {
        ShortenedUrls.Add(shortenedUrl);
        return Task.CompletedTask;
    }

    public Task<bool> AnyAsync(Code code)
        => Task.FromResult(ShortenedUrls.Any(x => x.Code == code));
}