

namespace Domain.Models.ProductModule;
public class Product :BaseEntity<int>
{
    public string ? Description { get; set; } 

    public string PictureUrl { get; set; } = null!; 

    public decimal Price { get; set; }



  
    public int BrandId { get; set; }    
    public ProductBrand productBrand { get; set; } = null!;




    public int TypeId { get; set; }
    public ProductType  productType { get; set; } =null!;   


}
