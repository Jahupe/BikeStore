using BikeStore.Core.Data;
using BikeStore.Core.Exceptions;
using BikeStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Products> GetProducts()
        {
             return _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Products> GetProductId(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public async Task<bool> InsertProduct(Products products)
        {
            var brand = await _unitOfWork.ProductRepository.GetById(products.BrandId);
            if (brand == null)
            {
                throw new BusinessException("Brand Doesn't Exist");
            }
            var ProductsByBrand = await _unitOfWork.ProductRepository.GetProductsByBrand(products.BrandId);
            if (ProductsByBrand.Count() > 2)
            {
                throw new BusinessException("Can not add more than 2 product with the same Brand");
            }

            await _unitOfWork.ProductRepository.Add(products);
            return true;

        }

        public async Task<bool> UpdateProduct(Products products)
        {
            //var brand = await _unitOfWork.BrandRepository.GetById(products.BrandId);
            //if (brand == null)
            //{
            //    throw new Exception("Brand Doesn't Exist");
            //}
            //if (products.ProductName.Contains("bicla"))
            //{
            //    throw new Exception("the Product Name can not contains the word bicla");
            //}
             _unitOfWork.ProductRepository.Update(products);
            await _unitOfWork.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.Delete(id);
            return true;
        }
    }
}
