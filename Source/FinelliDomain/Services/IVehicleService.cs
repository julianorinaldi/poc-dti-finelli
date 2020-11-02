using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliDomain.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> ListAsync();

        Task<Vehicle> GetAsync(string chassi);

        void AddItem(Vehicle vehicle);

        void UpdateItem(Vehicle vehicle);

        void DeleteItem(string chassi);
    }
}