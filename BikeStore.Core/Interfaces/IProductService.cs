using BikeStore.Core.CustomEntities;
using BikeStore.Core.Data;
using BikeStore.Core.QueryFilters;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface IProductService
    {
        PagedList<Products> GetProducts(ProductQueryFilter filters);
        Task<Products> GetProductId(int id);
        Task<bool> InsertProduct(Products products);
        Task<bool> UpdateProduct(Products products);
        Task<bool> DeleteProduct(int id);
    }
}