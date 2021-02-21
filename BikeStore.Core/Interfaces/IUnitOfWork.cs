using BikeStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       IProductRepository ProductRepository { get; }
       IRepository<Brands> BrandRepository { get; }
       void SaveChanges();
       Task SaveChangesAsync();

    }
}
