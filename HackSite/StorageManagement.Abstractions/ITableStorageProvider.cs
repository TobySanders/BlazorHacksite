using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageProviders.Abstractions
{
    public interface ITableStorageProvider<TModel,TKey>
    {
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        Task<TModel> ReadAsync(TKey key);
        Task<List<TModel>> ReadAllAsync();
        Task DeleteAsync(TKey key);
    }
}
