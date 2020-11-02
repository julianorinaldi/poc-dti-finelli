using FinelliApplicationVehicle.Persistence.EntityConfigurations;
using FinelliDataCore.Persistence.Contexts;
using FinelliDomainVehicle;
using Microsoft.EntityFrameworkCore;

namespace FinelliApplicationVehicle.Persistence.Contexts
{
    public class MemoryDbContextCRUDVehicle : MemoryDbContextBase
    {
        public MemoryDbContextCRUDVehicle(DbContextOptions<MemoryDbContextCRUDVehicle> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
        }
    }
}