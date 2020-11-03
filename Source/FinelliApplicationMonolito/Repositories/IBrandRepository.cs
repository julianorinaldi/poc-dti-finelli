using FinelliDomainMonolito;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliApplicationMonolito.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> ListAsync();

        Task AddAync(Brand brand);

        Task<Brand> FindByIdAsync(string id);

        Task<Brand> FindByNameAsync(string name);

        void Update(Brand brand);

        void Remove(Brand brand);
    }
}