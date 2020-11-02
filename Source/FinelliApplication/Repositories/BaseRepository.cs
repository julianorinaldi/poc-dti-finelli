using FinelliApplicationVehicle.Persistence.Contexts;

namespace FinelliApplicationVehicle.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected readonly T _context;

        public BaseRepository(T context)
        {
            _context = context;
        }
    }
}