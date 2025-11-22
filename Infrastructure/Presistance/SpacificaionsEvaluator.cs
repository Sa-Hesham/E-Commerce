


namespace Presistance;
internal  static class SpacificaionsEvaluator
{
    public static IQueryable<TEntity> CreateQuery<TEntity, Tkey>(IQueryable<TEntity> inputQuery,
        ISpacifications<TEntity, Tkey> spacifications) where TEntity : BaseEntity<Tkey>
    {
        var query = inputQuery;

        if (spacifications .Criteria is not  null )
        
             query= query.Where(spacifications.Criteria);
        

        if (spacifications.IsPaginated)
        
            query = query.Skip(spacifications.Skip).Take(spacifications.Take);
        


        if (spacifications.OrderBy is not null)
      
            query = query.OrderBy(spacifications.OrderBy);  
       

        if(spacifications.OrderByDescending is not null)
       
            query = query.OrderByDescending(spacifications.OrderByDescending);
       

        if (spacifications.IncludeExeprssion is not null && spacifications.IncludeExeprssion.Any())
        
            foreach(var exp in spacifications.IncludeExeprssion)
            {
                query = query.Include(exp);
            }
        

       

        return query;
    }
}
