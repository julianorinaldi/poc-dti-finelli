using FinelliApplicationMonolito.Persistence.Contexts;
using FinelliDataCore.Repositories;
using FinelliDomainMonolito;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinelliApplicationMonolito.Repositories
{
    public class BrandRepository : BaseRepository<MemoryDbContextMonolito>, IBrandRepository
    {
        public BrandRepository(MemoryDbContextMonolito context) : base(context)
        {
        }

        public async Task AddAync(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            _context.SaveChanges();
        }

        public async Task<Brand> FindByIdAsync(string name)
        {
            var objResult = await _context.Brands.FirstOrDefaultAsync(x => x.Name == name);
            return objResult;
        }

        public async Task<IEnumerable<Brand>> ListAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public void Remove(Brand brand)
        {
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

        public void Update(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }
    }
}