using BikeStore.Core.Data;
using BikeStore.Core.Interfaces;
using BikeStore.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace BikeStore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BikeStoresContext _context;
        private readonly IProductRepository _productrepository;
        private readonly IRepository<Brands> _brandrepository;
        private readonly ISecurityRepository _securityrepository;

        public UnitOfWork(BikeStoresContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => _productrepository ?? new ProductRepository(_context);
        public IRepository<Brands> BrandRepository => _brandrepository ?? new BaseRepository<Brands>(_context);
        public ISecurityRepository SecurityRepository => _securityrepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
