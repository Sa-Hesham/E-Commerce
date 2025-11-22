using Domain.Models.ProductModule;
using Shared.EntitiesParametrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifaions;
internal class ProductCountSpacficaions : BaseSpacefications<Product, int>
{
    public ProductCountSpacficaions(ProductParameters parameters) : base(p => (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId)
        && (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId)
        && (string.IsNullOrEmpty(parameters.Search) || p.Name.ToLower().Contains(parameters.Search)))

    {

    }
}
