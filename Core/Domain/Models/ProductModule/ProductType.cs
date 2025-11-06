

namespace Domain.Models.ProductModule;
public class ProductType :BaseEntity <int>
{

    public ICollection<Product> products { get; set; } = new List<Product>();

}
