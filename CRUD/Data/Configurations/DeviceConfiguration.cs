using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Data.Configurations;

public class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.Property(e => e.Name)
            .HasMaxLength(250);
        builder.Property(e => e.ICon)
            .HasMaxLength(100);

        builder.HasMany(e => e.Games)
            .WithOne(e => e.Device)
            .HasForeignKey(e => e.DeviceId);

        

        builder.HasData(new Device[]
        {
            new Device { Id = 1, Name="PlayStation", ICon="bi bi-playstation"},
            new Device { Id = 2, Name = "xbox", ICon="bi bi-xbox" },
            new Device { Id = 3, Name = "Nintendo Switch", ICon = "bi bi-nintendo-switch" },
            new Device { Id = 4, Name = "PC" , ICon = "bi bi-pc-display" }
        });
    }
}
