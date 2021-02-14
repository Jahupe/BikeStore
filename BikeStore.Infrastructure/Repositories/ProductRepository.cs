using BikeStore.Core.Data;
using BikeStore.Core.Interfaces;
using BikeStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BikeStoresContext _context;
        public ProductRepository(BikeStoresContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Products>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();             
            return products;
        }      
    }
}
