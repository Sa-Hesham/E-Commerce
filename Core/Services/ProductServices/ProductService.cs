using AutoMapper;
using Domain.Contracts;
using Domain.Models.ProductModule;

namespace Services.ProductServices;
public class ProductService(IUnitOfWork _getService, IMapper _mapper) : IProductService
{
    
    
   
    public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
    {
      var productBrand =  await _getService.GetRepository<ProductBrand,int>().GetAllAsync();
       return _mapper.Map<IEnumerable<BrandResultDto>>(productBrand);
    }

    public  async Task<IEnumerable<ProductResultDto>> GetAllProductsAsync()
    {
        var products = await _getService.GetRepository<Product,int>().GetAllAsync();    
        
        return _mapper.Map<IEnumerable<ProductResultDto>>(products);
    }

    public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
    {
      var alltypes = await  _getService.GetRepository<ProductType,int>().GetAllAsync();    
        return _mapper.Map<IEnumerable<TypeResultDto>>(alltypes);
    }

    public async Task<ProductResultDto> GetProductAsync(int Id)
    {
        
        var product = await _getService.GetRepository<Product,int >().GetByIdAsync(Id); 

        return _mapper.Map<ProductResultDto>(product);  
    }
}
