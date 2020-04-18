using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageProviders.Abstractions
{
    public interface ITableStorageProvider<TModel>
    {
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        Task<TModel> ReadAsync(string key);
        Task<List<TModel>> ReadAllAsync();
        Task DeleteAsync(string key);
    }
}
