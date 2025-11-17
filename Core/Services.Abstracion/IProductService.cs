
using Shared.Dtos;
using Shared.EntitiesParametrs;
using Shared.Enums;

namespace Services.Abstracion;
public interface IProductService
{

    // GetAllProducts 

    Task<PaginationREsult<ProductResultDto>> GetAllProductsAsync(ProductParameters parameters);



   // Get BroductbyId 

    Task <ProductResultDto> GetProductAsync (int Id);




    //Get All Brands 


    Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();



    //GetAllType 

    Task<IEnumerable<TypeResultDto>>GetAllTypesAsync(); 







}
