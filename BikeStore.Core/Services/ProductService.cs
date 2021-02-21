using BikeStore.Core.Data;
using BikeStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Products> GetProductId(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public async Task<bool> InsertProduct(Products products)
        {
            var brand = _unitOfWork.ProductRepository.GetById(products.BrandId);
            if (brand == null) 
            {
                throw new Exception("Brand Doesn't Exist");
            }

            return await _unitOfWork.ProductRepository.Add(products);
        }

        public async Task<bool> UpdateProduct(Products products)
        {
            var brand = await _unitOfWork.BrandRepository.GetById(products.BrandId);
            if (brand == null)
            {
                throw new Exception("Brand Doesn't Exist");
            }
            if (products.ProductName.Contains("bicla"))
            {
                throw new Exception("the Product Name can not contains the word bicla");
            }
            return await _unitOfWork.ProductRepository.Update(products);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _unitOfWork.ProductRepository.Delete(id);
        }
    }
}
