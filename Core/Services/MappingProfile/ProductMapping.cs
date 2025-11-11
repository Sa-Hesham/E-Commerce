using AutoMapper;
using Domain.Models.ProductModule;

namespace Services.MappingProfile;

internal class ProductMapping :Profile
{
    public ProductMapping()
    {
        CreateMap<ProductType, TypeResultDto>();
        CreateMap < ProductBrand,BrandResultDto>();

        CreateMap<Product, ProductResultDto>()
            .ForMember(des => des.BrandName, options => options.MapFrom(src => src.productBrand.Name))
            .ForMember(des => des.TypeName, options => options.MapFrom(src => src.productType.Name));
            
    }
}
