using FinelliApplicationVehicle.Persistence.EntityConfigurations;
using FinelliDomain;
using Microsoft.EntityFrameworkCore;

namespace FinelliApplicationVehicle.Persistence.Contexts
{
    public class MemoryDbContextMonolito : MemoryDbContextBase
    {
        public MemoryDbContextMonolito(DbContextOptions<MemoryDbContextMonolito> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandEntityTypeConfiguration());
        }
    }
}