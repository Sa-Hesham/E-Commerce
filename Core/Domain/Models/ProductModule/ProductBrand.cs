

namespace Domain.Models.ProductModule;
public class ProductBrand :BaseEntity<int>
{



    public ICollection<Product> products { get; set; } = new List<Product>();
}
