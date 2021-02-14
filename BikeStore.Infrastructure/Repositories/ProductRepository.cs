using BikeStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeStore.Infrastructure.Repositories
{
    public class ProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            var products = Enumerable.Range(1, 10).Select(x => new Product
            {
              product_id = x,
              product_name = $"Producto {x}",
              brand_id = x,
              category_id = x,
              model_year = 2021,
              list_price = x * 123
            });

            return products;
        }
    }
}
