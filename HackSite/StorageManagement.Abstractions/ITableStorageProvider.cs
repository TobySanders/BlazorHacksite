using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageProviders.Abstractions
{
    public interface ITableStorageProvider<TTableEntity,TKey>
    {
        Task<TTableEntity> CreateAsync(TTableEntity model);
        Task<TTableEntity> UpdateAsync(TTableEntity model);
        Task<TTableEntity> ReadAsync(TKey key);
        Task<List<TTableEntity>> ReadAllAsync();
        Task DeleteAsync(TKey key);
    }
}
