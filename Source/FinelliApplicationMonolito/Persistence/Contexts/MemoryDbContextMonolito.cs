using FinelliApplicationMonolito.Persistence.EntityConfigurations;
using FinelliDataCore.Persistence.Contexts;
using FinelliDomainMonolito;
using Microsoft.EntityFrameworkCore;

namespace FinelliApplicationMonolito.Persistence.Contexts
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