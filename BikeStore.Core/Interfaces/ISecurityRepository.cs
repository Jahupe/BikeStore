using BikeStore.Core.Entities;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface ISecurityRepository: IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}