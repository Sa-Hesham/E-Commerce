

using Domain.Models;

namespace Domain.Contracts;
public interface IGenaricRepository <TEntity,Tkey > where TEntity : BaseEntity<Tkey>
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(Tkey id);


    Task AddAsync (TEntity entity);



    void Delete (TEntity entity);



    void Update  (TEntity entity);




    Task<IEnumerable<TEntity>> GetAllAsync(ISpacifications<TEntity,Tkey> spacifications );

    Task<TEntity?> GetByIdAsync(ISpacifications<TEntity, Tkey> spacifications);


    Task<int> GetCountAsync(ISpacifications<TEntity, Tkey> spacifications);


}
