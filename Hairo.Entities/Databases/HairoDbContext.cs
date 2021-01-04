using Hairo.Entities.Location;
using Microsoft.EntityFrameworkCore;

namespace Hairo.Entities.Databases
{
    public class HairoDbContext : DbContext
    {
        public HairoDbContext(DbContextOptions<HairoDbContext> options) : base(options) { }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ChildService> ChildServices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<LocationAddress> LocationAddresses { get; set; }
        public DbSet<LocationPhoto> LocationPhotos { get; set; }
    }
}
