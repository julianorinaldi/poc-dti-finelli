using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliDomain.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> ListAsync();

        Task AddAync(Vehicle vehicle);

        Task<Vehicle> FindByIdAsync(string chassi);

        void Update(Vehicle vehicle);

        void Remove(Vehicle vehicle);
    }
}