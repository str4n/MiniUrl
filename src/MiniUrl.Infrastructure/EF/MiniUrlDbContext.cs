using Microsoft.EntityFrameworkCore;
using MiniUrl.Domain.ShortenedUrls.Url;
using MiniUrl.Domain.Users.User;

namespace MiniUrl.Infrastructure.EF;

internal sealed class MiniUrlDbContext : DbContext
{
    public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    public DbSet<User> Users { get; set; }

    public MiniUrlDbContext(DbContextOptions<MiniUrlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.HasDefaultSchema("url");
    }
}