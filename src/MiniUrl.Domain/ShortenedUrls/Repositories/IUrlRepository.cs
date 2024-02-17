using MiniUrl.Domain.ShortenedUrls.Url;

namespace MiniUrl.Domain.ShortenedUrls.Repositories;

public interface IUrlRepository
{
    Task<ShortenedUrl> GetAsync(Code code);
    Task AddAsync(ShortenedUrl shortenedUrl);
    Task<bool> AnyAsync(Code code);
}