using BikeStore.Core.Interfaces;
using BikeStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BikeStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetProductID(int id)
        {
            var product = await _productRepository.GetProductId(id);
            return Ok(product);
        }
    }
}
