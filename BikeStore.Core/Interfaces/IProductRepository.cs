﻿using BikeStore.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Core.Interfaces
{
    public interface IProductRepository:IRepository<Products>
    {
        Task<IEnumerable<Products>> GetProductsByBrand(int BrandId);
        //Task<Products> GetProductId(int id);
        //Task<bool> InsertProduct(Products products);
        //Task<bool> UpdateProduct(Products products);
        //Task<bool> DeleteProduct(int id);
    }
}
