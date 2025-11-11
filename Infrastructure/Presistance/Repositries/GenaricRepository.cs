using Domain.Contracts;
using Domain.Models;
using Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Repositries;
internal class GenaricRepository<TEntity, Tkey>(ApplicatonDbcontext dbcontext) : IGenaricRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
{
    private readonly ApplicatonDbcontext _dbcontext = dbcontext;
    public async Task AddAsync(TEntity entity) => await _dbcontext.Set<TEntity>().AddAsync(entity);


    public void Delete(TEntity entity) =>_dbcontext.Set<TEntity>().Remove(entity);  

    
  

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>await _dbcontext.Set<TEntity>().ToListAsync();
  

    public async Task<TEntity?> GetByIdAsync(Tkey id) => await _dbcontext.FindAsync<TEntity>(id);   
 

    public void Update(TEntity entity) => _dbcontext.Set<TEntity>().Update(entity); 
  
}
