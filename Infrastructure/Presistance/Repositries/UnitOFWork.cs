using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Presistance.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Repositries;
public class UnitOFWork : IUnitOfWork
{
    private readonly ApplicatonDbcontext _dbcontext;
    private readonly ConcurrentDictionary<string, object> _repositories;


    public UnitOFWork(ApplicatonDbcontext dbcontext)
    {
        _dbcontext = dbcontext;
        _repositories = new();
    }

   
    

    public IGenaricRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
    {
            var key = typeof(TEntity).Name;
        return (IGenaricRepository < TEntity, Tkey >) _repositories.GetOrAdd(key, (_)=> new GenaricRepository<TEntity,Tkey>(_dbcontext));

        //if (!_repositories.ContainsKey(key))
        //{
        //    _repositories[key] = new GenaricRepository<TEntity, Tkey>(_dbcontext);
        //}

        //return (IGenaricRepository<TEntity, Tkey>)_repositories[key];
           
    }

    public async Task<int> SaveChangesAsync() => await _dbcontext.SaveChangesAsync();

}
