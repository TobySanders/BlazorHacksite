using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserManagement.Abstractions
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(TKey key);
        Task<List<TEntity>> ReadMultipleAsync(List<TKey> keys, bool descending = false);
        Task<List<TEntity>> ReadAllAsync(bool descending = false);
        Task<List<TEntity>> QueryAsync(Func<TEntity,bool> filter, bool descending = false);
        Task<List<TEntity>> QueryAsync<TSortKey>(Func<TEntity, bool> filter, Func<TEntity, TSortKey> orderBy, bool descending = false);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey key);
    }
}
