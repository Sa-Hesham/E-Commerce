

using Domain.Contracts;
using Domain.Models;
using System.Linq.Expressions;

namespace Services.Specifaions;

internal abstract class BaseSpacefications<TEntity, Tkey> : ISpacifications<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
{

    protected BaseSpacefications() { }
    
    protected BaseSpacefications(Expression<Func<TEntity, bool>> ? criteria )
       
    {
        Criteria = criteria;

    }
    public Expression<Func<TEntity, bool>>? Criteria {  get;  private set; }
    public ICollection<Expression<Func<TEntity, object>>> IncludeExeprssion { get; } = [];

    protected void AddInclude(Expression<Func<TEntity, object>> includeExeprssion)
    {
        IncludeExeprssion.Add(includeExeprssion);
     
    }

    public Expression<Func<TEntity, object>>? OrderBy {  get; private set; }

    public Expression<Func<TEntity, object>>? OrderByDescending {  get; private set; }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDesc)
    {
        OrderByDescending = orderByDesc;
    }

}
