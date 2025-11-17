
namespace Presistance.Repositries;

internal class GenaricRepository<TEntity, Tkey>(ApplicatonDbcontext dbcontext) : IGenaricRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
{
    private readonly ApplicatonDbcontext _dbcontext = dbcontext;
    public async Task AddAsync(TEntity entity) => await _dbcontext.Set<TEntity>().AddAsync(entity);


    public void Delete(TEntity entity) =>_dbcontext.Set<TEntity>().Remove(entity);  

    
  

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>await _dbcontext.Set<TEntity>().ToListAsync();


    public async Task<TEntity?> GetByIdAsync(Tkey id) => await _dbcontext.FindAsync<TEntity>(id);
    public void Update(TEntity entity) => _dbcontext.Set<TEntity>().Update(entity);

    #region Spacefications
    public  async Task<IEnumerable<TEntity>> GetAllAsync(ISpacifications<TEntity, Tkey> spacifications)
    {
        //EntryPoint

        IQueryable<TEntity> query = _dbcontext.Set<TEntity>();

       return  await SpacificaionsEvaluator.CreateQuery<TEntity, Tkey>(query, spacifications) .ToArrayAsync();


      
    }

    public async Task<TEntity?> GetByIdAsync(ISpacifications<TEntity, Tkey> spacifications)
    {
        return await SpacificaionsEvaluator.CreateQuery(_dbcontext.Set<TEntity>(), spacifications) .FirstOrDefaultAsync();
    }

    public async Task<int> GetCountAsync(ISpacifications<TEntity, Tkey> spacifications)
    {
        return await SpacificaionsEvaluator.CreateQuery (_dbcontext.Set<TEntity>(),spacifications).CountAsync();



    }


    #endregion
}
