using MiniUrl.Domain.Url;

namespace MiniUrl.Domain.Repositories;

public interface IUrlRepository
{
    Task<ShortenedUrl> GetAsync(Guid id);
    Task AddAsync(ShortenedUrl shortenedUrl);
    Task<bool> AnyAsync(Code code);
}