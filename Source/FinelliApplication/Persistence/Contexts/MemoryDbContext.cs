using FinelliApplication.Persistence.EntityConfigurations;
using FinelliDomain;
using Microsoft.EntityFrameworkCore;

namespace FinelliApplication.Persistence.Contexts
{
    public class MemoryDbContext : DbContext
    {
        public MemoryDbContext(DbContextOptions<MemoryDbContext> options) : base(options)
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