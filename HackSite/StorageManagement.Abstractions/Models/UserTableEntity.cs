using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
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
