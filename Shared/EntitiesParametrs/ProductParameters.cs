using Shared.Enums;


namespace Shared.EntitiesParametrs;
public class ProductParameters
{
  public  int? TypeId { get; set; }   
  public int? BrandId { get; set; }  
 public ProductSortingOptions  sort {  get; set; }
  
    public string ?Search {  get; set; }    
}
