using FinelliApplication.Persistence.Contexts;

namespace FinelliApplication.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MemoryDbContext _context;

        public BaseRepository(MemoryDbContext context)
        {
            _context = context;
        }
    }
}