using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;

namespace MiniUrl.Tests.Unit.Helpers.Repositories;

internal sealed class InMemoryUrlRepository : IUrlRepository
{
    private static readonly List<ShortenedUrl> ShortenedUrls = new()
    {
        new ShortenedUrl("https://www.youtube.com/", "https://localhost:9990/youtube", "youtube", DateTime.Now, DateTime.MaxValue)
    };

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