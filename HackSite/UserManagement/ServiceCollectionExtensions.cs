using Microsoft.Extensions.DependencyInjection;
using StorageProviders;
using StorageProviders.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserRepository(this IServiceCollection services)
        {
            return services.AddSingleton<ITableStorageProvider<User>, UserTableStorageProvider>()
                .AddSingleton<IFileStorageProvider, BlobStorageProvider>();
        }
    }
}
