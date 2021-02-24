using AutoMapper;
using BikeStore.Api.Responses;
using BikeStore.Core.CustomEntities;
using BikeStore.Core.Data;
using BikeStore.Core.DTOs;
using BikeStore.Core.Interfaces;
using BikeStore.Core.QueryFilters;
using BikeStore.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BikeStore.Api.Controllers
{
    [Authorize]
    [Produces("Application/Json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;
        private readonly IMapper _mapper;
        private readonly IUriServices _uriservices;

        public ProductController(IProductService productservice, IMapper mapper, IUriServices uriservices)
        {
            _productservice = productservice;
            _mapper = mapper;
            _uriservices = uriservices;
        }

        /// <summary>
        /// Retrieve all Products
        /// </summary>
        /// <param name="filters">Filters  to Apply</param>
        /// <returns></returns>

        [HttpGet(Name = nameof(Get))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type= typeof(ApiResponse<IEnumerable<ProductsDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get([FromQuery]ProductQueryFilter filters)
        {
            var products =  _productservice.GetProducts(filters);
            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);

            var metadata = new MetaData
            {
                TotalCount = products.TotalCount,
                PageSize = products.PageSize,
                CurrentPage = products.CurrentPage,
                TotalPages = products.TotalPages,
                HasNextPage = products.HasNextPage,
                HasPreviousPage = products.HasPreviousPage,
                NexPageUrl = _uriservices.GetProductPaginationUri(filters, Url.RouteUrl(nameof(Get))).ToString(),
                PreviousPageUrl = _uriservices.GetProductPaginationUri(filters, Url.RouteUrl(nameof(Get))).ToString()
            };

            var response = new ApiResponse<IEnumerable<ProductsDto>>(productsDto)
            {
                Meta = metadata
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
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
