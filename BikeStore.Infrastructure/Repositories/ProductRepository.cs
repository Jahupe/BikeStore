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

        public async Task<Products> GetProductId(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.id == id);
            return product;
        }

        public async Task<bool> InsertProduct(Products products)
        {
            _context.Products.Add(products);
            int rows= await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> UpdateProduct(Products products) 
        {
            var currentproducts = await GetProductId(products.id);
            currentproducts.ProductName = products.ProductName;
            currentproducts.BrandId = products.BrandId;
            currentproducts.CategoryId = products.CategoryId;
            currentproducts.ModelYear = products.ModelYear;
            currentproducts.ListPrice = products.ListPrice;
            int rows =await _context.SaveChangesAsync();
            return rows > 0;
        }


        public async Task<bool> DeleteProduct(int id)
        {
            var currentproduct = await GetProductId(id);
            _context.Products.Remove(currentproduct);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
