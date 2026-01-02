using AutoMapper;
using MyStore.Application.Dtos;
using MyStore.Domain.Entities;

namespace MyStore.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<ProductOrder, ProductOrderDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
