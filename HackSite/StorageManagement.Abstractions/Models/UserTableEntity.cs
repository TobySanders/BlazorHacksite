using Microsoft.WindowsAzure.Storage.Table;
using System;
using UserManagement.Abstractions.Models;

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
            PartitionKey = "0";
            RowKey = Id.ToString();
        }

        public UserTableEntity(User user)
        {
            Id = user.Id == Guid.Empty? Guid.NewGuid() : user.Id;
            Username = user.Username;

            RowKey = Id.ToString();
            PartitionKey = "0";
        }
    }
}
