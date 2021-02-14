using BikeStore.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetProducts();
    }
}
