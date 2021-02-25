using BikeStore.Core.Entities;
using BikeStore.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace BikeStore.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userlogin)
        {
            return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userlogin);
        }
        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.SecurityRepository.Add(security);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
