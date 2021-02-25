using BikeStore.Core.Entities;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userlogin);
        Task RegisterUser(Security security);
    }
}