using BikeStore.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
