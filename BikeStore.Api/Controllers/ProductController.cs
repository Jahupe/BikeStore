using BikeStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct() 
        {
            var products = new ProductRepository().GetProducts();
            return Ok(products);
        }
    }
}
