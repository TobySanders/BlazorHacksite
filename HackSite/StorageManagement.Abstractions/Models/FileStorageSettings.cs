namespace StorageProviders.Abstractions.Models
{
    public class FileStorageSettings
    {
        public string BlobConnectionString { get; set; }
        public string ContainerName { get; set; }
    }
}
