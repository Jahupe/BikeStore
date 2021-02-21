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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandservice;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandservice, IMapper mapper)
        {
            _brandservice = brandservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brands =  _brandservice.GetBrands();
            var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);
            var response = new ApiResponse<IEnumerable<BrandDto>>(brandsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(int id)
        {
            var brand = await _brandservice.GetBrandId(id);
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BrandDto brandDto)
        {
            var brands = _mapper.Map<Brands>(brandDto);
            var result = await _brandservice.InsertBrand(brands);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, BrandDto brandDto)
        {
            var brands = _mapper.Map<Brands>(brandDto);
            brands.id = id;
            var result = await _brandservice.UpdateBrand(brands);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _brandservice.DeleteBrand(id);
            return Ok(result);
        }
    }
}
