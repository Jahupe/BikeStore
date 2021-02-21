using BikeStore.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> GetProductId(int id);
        Task<bool> InsertProduct(Products products);
        Task<bool> UpdateProduct(Products products);
        Task<bool> DeleteProduct(int id);
    }
}