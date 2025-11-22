

using Domain.Models.ProductModule;
using Shared.EntitiesParametrs;
using Shared.Enums;

namespace Services.Specifaions;

internal class ProductWithBrandAndTypeSpacifications:BaseSpacefications<Product , int> 
{
    public ProductWithBrandAndTypeSpacifications(ProductParameters parameters) :
        base(p => (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId)
        && (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId)
        && (string.IsNullOrEmpty(parameters.Search) || p.Name.ToLower().Contains(parameters.Search)))


    {
        AddInclude(p=>p.productType);
        AddInclude(p=>p.productBrand);

        switch (parameters.sort)
        {
            case ProductSortingOptions.NameAsc:
               AddOrderBy(p=>p.Name); 
                break;  
                
                case ProductSortingOptions.NameDesc:
                AddOrderByDescending(p => p.Name);
                break;

                case ProductSortingOptions.PriceAsc: 
                AddOrderBy(p=>p.Price); 
                break;

                case ProductSortingOptions.PriceDesc:
                AddOrderByDescending(p => p.Price);
                break;

                default:
                break;


        }



        AddPagination(parameters.PageSize,parameters.PageIndex);
    }


    public ProductWithBrandAndTypeSpacifications (int id) :base(p=>p.Id==id)
    {
        AddInclude(p => p.productType);
        AddInclude(p => p.productBrand);
    }

   
}
