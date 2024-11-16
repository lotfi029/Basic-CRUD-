using CRUD.Data.Configurations;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public virtual DbSet<Device> Devices { get; set; }
    public virtual DbSet<Game> Games { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<GameDevice> GameDevices { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameConfiguration).Assembly);
    }
}
