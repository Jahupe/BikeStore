using AutoMapper;
using BikeStore.Api.Responses;
using BikeStore.Core.Data;
using BikeStore.Core.DTOs;
using BikeStore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;
        private readonly IMapper _mapper;
        public ProductController(IProductService productservice, IMapper mapper)
        {
            _productservice = productservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = _productservice.GetProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);
            var response = new ApiResponse<IEnumerable<ProductsDto>>(productsDto);
            return Ok(response);
        }


        [HttpGet ("{id}")]
        public async Task<IActionResult> GetID(int id)
        {
            var product = await _productservice.GetProductId(id);
            var productsDto = _mapper.Map<ProductsDto>(product);
            var response = new ApiResponse<ProductsDto>(productsDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductsDto productsDto)
        {
            var products = _mapper.Map<Products>(productsDto);
            var result = await _productservice.InsertProduct(products);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,ProductsDto productsDto)
        {
            var products = _mapper.Map<Products>(productsDto);
            products.id = id;
            var result = await _productservice.UpdateProduct(products);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productservice.DeleteProduct(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
