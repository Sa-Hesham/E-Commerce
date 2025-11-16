using Shared.Enums;


namespace Shared.EntitiesParametrs;
public class ProductParameters
{
	private const int DefaultBageSize = 5;
	private const int MaxPageSize = 10;
    public int? TypeId { get; set; }
    public int? BrandId { get; set; }
    public ProductSortingOptions sort { get; set; }

    public string? Search { get; set; }


    public int  PageIndex { get; set; }

	private int _PageSize = DefaultBageSize; 

	public int PageSize
	{
		get { return _PageSize; }
		set { _PageSize = value > MaxPageSize ? MaxPageSize : value; }
	}



}
