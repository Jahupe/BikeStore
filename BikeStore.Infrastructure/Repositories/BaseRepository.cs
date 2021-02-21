using BikeStore.Core.Entities;
using BikeStore.Core.Interfaces;
using BikeStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly BikeStoresContext _context;
        private readonly DbSet<T> _entities;

        public BaseRepository(BikeStoresContext context)
        {
            _context = context;
            _entities = context.Set<T>(); 
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<bool> Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }                  

      
    }
}
