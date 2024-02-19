using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniUrl.Domain.Users.User;

namespace MiniUrl.Infrastructure.EF.Configs;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new(x))
            .IsRequired();
        
        builder.Property(x => x.Username)
            .HasConversion(x => x.Value, x => new(x))
            .IsRequired();
        
        builder.Property(x => x.Password)
            .HasConversion(x => x.Value, x => new(x))
            .IsRequired();

        builder.Property(x => x.State)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.CreatedAt).IsRequired();
    }
}