using Microsoft.AspNetCore.Mvc;
using Services.Abstracion.ServicesManger;
using Shared.Dtos;
using Shared.EntitiesParametrs;
using Shared.Enums;


namespace Presentaions.Controllers;

[ApiController]
[Route ("api/[Controller]")]
public class ProductsController (IServiceManager _serviceManager):ControllerBase
{
    [HttpGet] 

    public async Task<ActionResult<PaginationREsult<ProductResultDto>>> GetAllProductsAsync([FromQuery]ProductParameters parameters )
    {
      var products= await _serviceManager.productService.GetAllProductsAsync( parameters);
        if (products is null)

            return NotFound();

        return Ok(products);
        
      
    }




    [HttpGet ("Brands")]

    public async Task<ActionResult<BrandResultDto>> GetAllBrandsAsync()
    {
        var Brands = await _serviceManager.productService.GetAllBrandsAsync();

        if (Brands is null) 
            return NotFound();

        return Ok(Brands);

    }




    [HttpGet("types")] 

    public async Task<ActionResult<TypeResultDto>> GetAllPRoductsTypeAsync() {
    
     var type = await _serviceManager.productService.GetAllTypesAsync(); 
        if (type is null)  
            return NotFound();
        return Ok(type);
    
    }



    [HttpGet ("{id}")]

    public async Task<ActionResult<ProductResultDto>> GetProductAsync(int id )
    {

        var product = await _serviceManager.productService.GetProductAsync(id);
           
            if (product is null)    
                return NotFound();

            return Ok(product);
        
    }

}
