using Microsoft.EntityFrameworkCore;
using MiniUrl.Domain.Repositories;
using MiniUrl.Domain.Url;

namespace MiniUrl.Infrastructure.EF.Repositories;

internal sealed class UrlRepository : IUrlRepository
{
    private readonly MiniUrlDbContext _dbContext;

    public UrlRepository(MiniUrlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ShortenedUrl> GetAsync(Guid id)
        => _dbContext.ShortenedUrls.SingleOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(ShortenedUrl shortenedUrl)
    {
        await _dbContext.ShortenedUrls.AddAsync(shortenedUrl);
        await _dbContext.SaveChangesAsync();
    }

    public Task<bool> AnyAsync(Code code)
        => _dbContext.ShortenedUrls.AnyAsync(x => x.Code == code);
}