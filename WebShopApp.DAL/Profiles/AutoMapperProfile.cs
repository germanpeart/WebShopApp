using AutoMapper;
using WebShopApp.DAL.DTOs;
using WebShopApp.DAL.Models;

namespace WebShopApp.DAL.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
