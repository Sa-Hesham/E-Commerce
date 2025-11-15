

using Domain.Models.ProductModule;

namespace Services.Specifaions;

internal class ProductWithBrandAndTypeSpacifications:BaseSpacefications<Product , int> 
{
    public ProductWithBrandAndTypeSpacifications() :base(null)
    {
        AddInclude(p=>p.productType);
        AddInclude(p=>p.productBrand);
    }


    public ProductWithBrandAndTypeSpacifications (int id) :base(p=>p.Id==id)
    {
        AddInclude(p => p.productType);
        AddInclude(p => p.productBrand);
    }
}
