
using Shared.Dtos;

namespace Services.Abstracion;
public interface IProductService
{

    // GetAllProducts 

    Task<IEnumerable<ProductResultDto>> GetAllProductsAsync();



   // Get BroductbyId 

    Task <ProductResultDto> GetProductAsync (int Id);




    //Get All Brands 


    Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();



    //GetAllType 

    Task<IEnumerable<TypeResultDto>>GetAllTypesAsync(); 







}
