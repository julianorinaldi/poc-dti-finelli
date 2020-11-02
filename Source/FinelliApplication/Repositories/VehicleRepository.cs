using FinelliApplication.Persistence.Contexts;
using FinelliDomain;
using FinelliDomain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliApplication.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        public VehicleRepository(MemoryDbContext context) : base(context)
        {
        }

        public async Task AddAync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            _context.SaveChanges();
        }

        public async Task<Vehicle> FindByIdAsync(string chassi)
        {
            var objResult = await _context.Vehicles.FirstOrDefaultAsync(x => x.Chassi == chassi);
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