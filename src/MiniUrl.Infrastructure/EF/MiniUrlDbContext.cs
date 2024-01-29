using Microsoft.EntityFrameworkCore;
using MiniUrl.Domain.Url;

namespace MiniUrl.Infrastructure.EF;

internal sealed class MiniUrlDbContext : DbContext
{
    public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

    public MiniUrlDbContext(DbContextOptions<MiniUrlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.HasDefaultSchema("url");
    }
}