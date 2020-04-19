using Microsoft.WindowsAzure.Storage.Table;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Abstractions.Models
{
    public class UserTableEntity : TableEntity
    {
        public string Username { get; set; }
        public string BlobKey { get; set; }

        public UserTableEntity(string username)
        {
            Username = username;
            PartitionKey = "User";
            RowKey = Username;
        }
        public UserTableEntity(User user)
        {
            Username = user.Username;
            PartitionKey = "User";
            RowKey = Username;
        }
    }
}
