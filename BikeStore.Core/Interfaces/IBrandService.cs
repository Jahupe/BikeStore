using BikeStore.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<Brands> GetBrands();
        Task<Brands> GetBrandId(int id);
        Task<bool> InsertBrand(Brands brands);
        Task<bool> UpdateBrand(Brands brands);
        Task<bool> DeleteBrand(int id);
    }
}
