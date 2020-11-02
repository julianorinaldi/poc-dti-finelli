using FinelliApplicationVehicle.Persistence.EntityConfigurations;
using FinelliDomain;
using Microsoft.EntityFrameworkCore;

namespace FinelliApplicationVehicle.Persistence.Contexts
{
    public class MemoryDbContextCRUDVehicle : MemoryDbContextBase
    {
        public MemoryDbContextCRUDVehicle(DbContextOptions<MemoryDbContextCRUDVehicle> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
        }
    }
}