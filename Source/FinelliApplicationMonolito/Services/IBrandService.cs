using FinelliDomainMonolito;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliApplicationMonolito.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> ListAsync();

        Task<Brand> GetAsync(string name);

        void AddItem(Brand brand);

        void UpdateItem(Brand brand);

        void DeleteItem(string name);
    }
}