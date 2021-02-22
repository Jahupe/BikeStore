using BikeStore.Core.CustomEntities;
using BikeStore.Core.Data;
using BikeStore.Core.Exceptions;
using BikeStore.Core.Interfaces;
using BikeStore.Core.QueryFilters;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public ProductService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Products> GetProducts(ProductQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            var products =  _unitOfWork.ProductRepository.GetAll();
            if (filters.product_name != null)
            {
                products = products.Where(x => x.ProductName.ToLower().Contains(filters.product_name.ToLower()));
            }
            if (filters.brand_id != null)
            {
                products = products.Where(x => x.BrandId == filters.brand_id);
            }
            if (filters.category_id != null)
            {
                products = products.Where(x => x.CategoryId == filters.category_id);
            }

            var PagedProducts = PagedList<Products>.create(products,filters.PageNumber,filters.PageSize);

            return PagedProducts;
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
