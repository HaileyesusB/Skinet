using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Products, ProductReturnDto>()
                   .ForMember(d => d.ProductType, p => p.MapFrom(o => o.ProductType.Name))
                   .ForMember(d => d.ProductBrand, p => p.MapFrom(o => o.ProductBrand.Name))
                   .ForMember(d => d.PictureUrl, p => p.MapFrom<ProductUrlResolver>());
        }
    }
}
