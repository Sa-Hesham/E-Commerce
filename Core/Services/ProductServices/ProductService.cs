using AutoMapper;
using Domain.Contracts;
using Domain.Models.ProductModule;
using Domain.NotFoundException;
using Services.Specifaions;
using Shared.EntitiesParametrs;
using Shared.Enums;

namespace Services.ProductServices;
public class ProductService(IUnitOfWork _getService, IMapper _mapper) : IProductService
{
    
    
   
    public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
    {
      
        var productBrand = await _getService.GetRepository<ProductBrand, int>().GetAllAsync();
       return _mapper.Map<IEnumerable<BrandResultDto>>(productBrand);
    }

    public  async Task<PaginationREsult<ProductResultDto>> GetAllProductsAsync(ProductParameters parameters)
    {
        var Specification = new ProductWithBrandAndTypeSpacifications(parameters);
        var products = await _getService.GetRepository<Product,int>().GetAllAsync(Specification);    
        
        var prdouctresult= _mapper.Map<IEnumerable<ProductResultDto>>(products);
        int PageSize = prdouctresult.Count();
        var Countspac= new ProductCountSpacficaions(parameters);    
        int ToalCount = await _getService.GetRepository<Product,int>().GetCountAsync(Countspac);
        return new PaginationREsult<ProductResultDto>(PageSize, parameters.PageIndex, ToalCount, prdouctresult);
      
    }

    public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
    {
      var alltypes = await  _getService.GetRepository<ProductType,int>().GetAllAsync();    
        return _mapper.Map<IEnumerable<TypeResultDto>>(alltypes);
    }

    public async Task<ProductResultDto> GetProductAsync(int id)
    {
        var Specification = new ProductWithBrandAndTypeSpacifications(id);

        var product = await _getService.GetRepository<Product,int >().GetByIdAsync(Specification); 

      return  product is null ? throw new ProductNotFoundException(id) : _mapper.Map<ProductResultDto>(product);

    }
}
