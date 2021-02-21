using BikeStore.Core.Data;
using BikeStore.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Core.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Brands> GetBrands()
        {
            return _unitOfWork.BrandRepository.GetAll();
        }

        public async Task<Brands> GetBrandId(int id)
        {
            return await _unitOfWork.BrandRepository.GetById(id);
        }

        public async Task<bool> InsertBrand(Brands brands)
        {
            await  _unitOfWork.BrandRepository.Add(brands);
            return true;
        }

        public async Task<bool> UpdateBrand(Brands brands)
        {
            _unitOfWork.BrandRepository.Update(brands);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBrand(int id)
        {
            await _unitOfWork.BrandRepository.Delete(id);
            return true;
        }
    }
}
