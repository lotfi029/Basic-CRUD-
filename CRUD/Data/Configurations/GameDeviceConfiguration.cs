using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Data.Configurations;
public class GameDeviceConfiguration : IEntityTypeConfiguration<GameDevice>
{

    public void Configure(EntityTypeBuilder<GameDevice> builder)
    {
        builder.HasKey(e => new { e.DeviceId, e.GameId });
    }
}
