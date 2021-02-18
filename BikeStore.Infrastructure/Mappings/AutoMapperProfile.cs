using AutoMapper;
using BikeStore.Core.Data;
using BikeStore.Core.DTOs;

namespace BikeStore.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Products, ProductsDto>();
            CreateMap<ProductsDto, Products>();
        }

    }
}
