using StorageProviders.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class Repository<TEntity,TTableEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        private readonly ITableStorageProvider<TTableEntity, TKey> _tableStorageProvider;
        private readonly IEntityResolver<TTableEntity, TEntity> _entityResolver;

        public Repository(ITableStorageProvider<TTableEntity, TKey> tableStorageProvider, IEntityResolver<TTableEntity,TEntity> entityResolver)
        {
            _tableStorageProvider = tableStorageProvider;
            _entityResolver = entityResolver;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var tableEntity = _entityResolver.ToSourceType(entity);
            var tableResult = await _tableStorageProvider.CreateAsync(tableEntity);
            return _entityResolver.ToTargetType(tableResult);
        }

        public virtual async Task DeleteAsync(TKey key)
        {
            await _tableStorageProvider.DeleteAsync(key);
        }

        public virtual async Task<List<TEntity>> QueryAsync(Func<TEntity, bool> filter, bool descending = false)
        {
            var dataSet = await ReadAllAsync();
            var filterSet = dataSet.Where(filter).ToList();

            return OrderByKey(filterSet, descending);
        }

        public virtual async Task<List<TEntity>> QueryAsync<TSortKey>(Func<TEntity, bool> filter, Func<TEntity, TSortKey> orderBy, bool descending = false)
        {
            var dataSet = await ReadAllAsync();
            var filterSet = dataSet.Where(filter).ToList();

            if (descending)
            {
                return filterSet.OrderByDescending(orderBy).ToList();
            }
            return filterSet.OrderBy(orderBy).ToList();
        }

        public virtual async Task<List<TEntity>> ReadAllAsync(bool descending = false)
        {
            var dataSet = await _tableStorageProvider.ReadAllAsync();
            var entitySet = dataSet.Select(p => _entityResolver.ToTargetType(p)).ToList();

            return OrderByKey(entitySet, descending);
        }

        public virtual async Task<TEntity> ReadAsync(TKey key)
        {
            var tableResult =  await _tableStorageProvider.ReadAsync(key);
            return _entityResolver.ToTargetType(tableResult);
        }

        public virtual async Task<List<TEntity>> ReadMultipleAsync(List<TKey> keys, bool descending = false)
        {
            var dataSet = await ReadAllAsync();
            var filterSet = dataSet.Where(p => keys.Contains(p.Key)).ToList();

            return OrderByKey(filterSet, descending);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var tableEntity = _entityResolver.ToSourceType(entity);
            var tableResult = await _tableStorageProvider.UpdateAsync(tableEntity);
            return _entityResolver.ToTargetType(tableResult);
        }

        protected List<TEntity>OrderByKey(List<TEntity> entities, bool descending)
        {
            return (descending ? entities.OrderByDescending(p => p.Key) : entities.OrderBy(p => p.Key)).ToList();
        }
    }
}
