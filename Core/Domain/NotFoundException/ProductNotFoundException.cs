

namespace Domain.NotFoundException;
public class ProductNotFoundException : NotFound
{
    public ProductNotFoundException( int Id  )
        :base($" Product With Id {Id} not Foound ") { }
}
