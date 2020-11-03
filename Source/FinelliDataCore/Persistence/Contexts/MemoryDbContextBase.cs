using Microsoft.EntityFrameworkCore;

namespace FinelliDataCore.Persistence.Contexts
{
    public abstract class MemoryDbContextBase : DbContext
    {
        public MemoryDbContextBase(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}