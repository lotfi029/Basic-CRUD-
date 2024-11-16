using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Data.Configurations;
public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(250);

        builder.Property(e => e.Description)
            .HasMaxLength(2500);

        builder.Property(e => e.Cover)
            .HasMaxLength(500);

        builder.HasOne(e => e.Category)
            .WithMany(e => e.Games)
            .HasForeignKey(e => e.CategoryId);

        builder.HasMany(e => e.Devices)
            .WithOne(e => e.Game)
            .HasForeignKey(e => e.GameId);

    }
}
