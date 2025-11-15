

using Domain.Contracts;
using Domain.Models;
using System.Linq.Expressions;

namespace Services.Specifaions;

internal abstract class BaseSpacefications<TEntity, Tkey> : ISpacifications<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
{
    protected BaseSpacefications(Expression<Func<TEntity, bool>> ? criteria)
    {
        Criteria = criteria;
    }
    public ICollection<Expression<Func<TEntity, object>>> IncludeExeprssion { get; } = [];

    public Expression<Func<TEntity, bool>>? Criteria {  get;  private set; }  



   protected void AddInclude(Expression<Func<TEntity, object>> includeExeprssion)
    {
        IncludeExeprssion.Add(includeExeprssion);
    }
}
