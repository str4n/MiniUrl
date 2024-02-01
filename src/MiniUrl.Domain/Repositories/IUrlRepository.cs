using MiniUrl.Domain.Url;

namespace MiniUrl.Domain.Repositories;

public interface IUrlRepository
{
    Task<ShortenedUrl> GetAsync(Code code);
    Task AddAsync(ShortenedUrl shortenedUrl);
    Task<bool> AnyAsync(Code code);
}