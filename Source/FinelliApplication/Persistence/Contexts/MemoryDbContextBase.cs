using Microsoft.EntityFrameworkCore;

namespace FinelliApplicationVehicle.Persistence.Contexts
{
    public abstract class MemoryDbContextBase : DbContext
    {
        public MemoryDbContextBase(DbContextOptions options) : base(options)
        {
        }

        // Implementar na herança

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Implementar na herança
        }
    }
}