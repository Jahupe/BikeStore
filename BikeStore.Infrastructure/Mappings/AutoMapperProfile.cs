using AutoMapper;
using BikeStore.Core.Data;
using BikeStore.Core.DTOs;
using BikeStore.Core.Entities;

namespace BikeStore.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Products, ProductsDto>();
            CreateMap<ProductsDto, Products>();

            CreateMap<BrandDto, Brands>();
            CreateMap<Brands, BrandDto>();

            CreateMap<Security, SecurityDto>().ReverseMap();

        }

    }
}
