using System.Threading.Tasks;

namespace StorageProviders.Abstractions
{
    public interface IFileStorageProvider
    {
        Task<string> CreateStorageAsync(string key);
    }
}
