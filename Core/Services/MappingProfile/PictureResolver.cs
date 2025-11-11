using AutoMapper;
using Domain.Models.ProductModule;
using Microsoft.Extensions.Configuration;


namespace Services.MappingProfile;
public class PictureResolver(IConfiguration _configuration) : IValueResolver<Product, ProductResultDto, string>
{
    public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
    {
        if(string.IsNullOrEmpty(source.PictureUrl))
            return string.Empty;
        return $"{_configuration.GetSection("URlS")["BaseUrl"]}{source.PictureUrl}";
      
    }
}
