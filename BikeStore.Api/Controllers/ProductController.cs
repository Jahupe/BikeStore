﻿using AutoMapper;
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
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _productRepository.GetProducts();
            var ProductsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);
            return Ok(ProductsDto);
        }


        [HttpGet ("{id}")]
        public async Task<IActionResult> GetProductID(int id)
        {
            var product = await _productRepository.GetProductId(id);
            var ProductsDto = _mapper.Map<ProductsDto>(product);
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Products(ProductsDto productsDto)
        {
            var products = _mapper.Map<Products>(productsDto);
            await _productRepository.InsertProduct(products);
            return Ok(products);
        }

        //[HttpDelete]
        //public async Task<IActionResult> Products(Products products)
        //{
        //    await _productRepository.InsertProduct(products);
        //    return Ok(products);
        //}
    }
}
