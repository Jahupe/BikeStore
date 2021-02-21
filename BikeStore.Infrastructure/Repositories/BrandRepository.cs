using BikeStore.Core.Data;
using BikeStore.Core.Interfaces;
using BikeStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly BikeStoresContext _context;
        public BrandRepository(BikeStoresContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brands>> GetBrands()
        {
            var brands = await _context.Brands.ToListAsync();
            return brands;
        }

        public async Task<Brands> GetBrandId(int id)
        {
            var Brand = await _context.Brands.FirstOrDefaultAsync(x => x.id == id);
            return Brand;
        }

    }
}
