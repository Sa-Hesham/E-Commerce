
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Contracts;


public interface ISpacifications<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
{
    // include (x=>x.navigation)=> {TEntity,obj} coolections of objects
    public ICollection<Expression<Func<TEntity,object>>> IncludeExeprssion { get;}

    //where(t=>t.ID==id)<Tentity, bool >
    public Expression<Func<TEntity,bool>> ?Criteria { get;} 
}
