using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniUrl.Domain.Url;

namespace MiniUrl.Infrastructure.EF.Configs;

internal sealed class ShortenedUrlConfiguration : IEntityTypeConfiguration<ShortenedUrl>
{
    public void Configure(EntityTypeBuilder<ShortenedUrl> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ShortUrl)
            .HasConversion(x => x.Value, x => new(x))
            .IsRequired();
        
        builder.Property(x => x.LongUrl)
            .HasConversion(x => x.Value, x => new(x))
            .IsRequired();
        
        builder.Property(x => x.Code)
            .HasConversion(x => x.Value, x => new(x))
            .HasMaxLength(10)
            .IsRequired();

        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.CreatedAt).IsRequired();

        builder.Property(x => x.Expiry).IsRequired();
    }
}