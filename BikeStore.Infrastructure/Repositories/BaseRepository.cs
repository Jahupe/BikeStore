using BikeStore.Core.Entities;
using BikeStore.Core.Interfaces;
using BikeStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly BikeStoresContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(BikeStoresContext context)
        {
            _context = context;
            _entities = context.Set<T>(); 
        }
        public IEnumerable<T> GetAll()
        {
            return  _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            //return true;
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
             _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            //_context.SaveChangesAsync();

        }                  

      
    }
}
