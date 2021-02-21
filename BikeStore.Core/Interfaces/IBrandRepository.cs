using BikeStore.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brands> GetBrandId(int id);
        Task<IEnumerable<Brands>> GetBrands();
    }
}