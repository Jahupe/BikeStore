using BikeStore.Core.Data;
using BikeStore.Core.Interfaces;
using BikeStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Products>,IProductRepository
    {
        public ProductRepository(BikeStoresContext context): base(context){}
        public async Task<IEnumerable<Products>> GetProductsByBrand(int BrandId)
        {
            return await _entities.Where(x => x.BrandId == BrandId).ToListAsync();
        }
    }
}
