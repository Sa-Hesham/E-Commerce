

namespace Domain.Models;
  public abstract class BaseEntity <T> 
{
    public T ? Id { get; set; } 
    public string Name { get; set; } = null!;
   
}
