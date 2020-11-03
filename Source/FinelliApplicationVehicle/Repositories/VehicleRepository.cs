using FinelliApplicationVehicle.Persistence.Contexts;
using FinelliDataCore.Repositories;
using FinelliDomainVehicle;
using FinelliDomainVehicle.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliApplicationVehicle.Repositories
{
    public class VehicleRepository : BaseRepository<MemoryDbContextCRUDVehicle>, IVehicleRepository
    {
        public VehicleRepository(MemoryDbContextCRUDVehicle context) : base(context)
        {
        }

        public async Task AddAync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            _context.SaveChanges();
        }

        public async Task<Vehicle> FindByIdAsync(string id)
        {
            var objResult = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
            return objResult;
        }

        public async Task<IEnumerable<Vehicle>> ListAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public void Remove(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }

        public void Update(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }
    }
}