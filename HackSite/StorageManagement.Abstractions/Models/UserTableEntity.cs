using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace StorageProviders.Abstractions.Models
{
    public class UserTableEntity : TableEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public UserTableEntity()
        {

        }

        public UserTableEntity(Guid userId)
        {
            Id = userId;
            PartitionKey = "User";
            RowKey = Id.ToString();
        }
    }
}
