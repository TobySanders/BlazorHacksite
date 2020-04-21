using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Settings;
using System;
using System.Threading.Tasks;

namespace StorageProviders
{
    public class BlobStorageProvider : IFileStorageProvider
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageProvider(IOptions<FileStorageSettings> options)
        {
            _blobServiceClient = new BlobServiceClient(options.Value.BlobConnectionString);
        }

        public async Task<string> CreateStorageAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
