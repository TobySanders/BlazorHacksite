using UserManagement.Abstractions.Models;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Extensions.Options;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System.Collections.Generic;

namespace StorageProviders
{
    public class UserTableStorageProvider : ITableStorageProvider<User>
    {
        private readonly CloudStorageAccount cloudStorageAccount;
        private readonly CloudTableClient cloudTableClient;
        private readonly CloudTable usersTable;

        public UserTableStorageProvider(IOptions<TableSettings> tableSettings)
        {
            var connectionString = tableSettings.Value.ConnectionString;
            cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            usersTable = cloudTableClient.GetTableReference("Users");
        }

        public async Task<User> CreateAsync(User model)
        {
            await usersTable.CreateIfNotExistsAsync();
            var tableEntity = new UserTableEntity(model);
            var insertOperation = TableOperation.Insert(tableEntity);
            var result = await usersTable.ExecuteAsync(insertOperation);

            return result.ToUser();
        }

        public async Task<User> ReadAsync(string username)
        {
            await usersTable.CreateIfNotExistsAsync();

            var tableEntity = new UserTableEntity(username);

            var retrieveOperation = TableOperation.Retrieve<UserTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await usersTable.ExecuteAsync(retrieveOperation);

            return result.ToUser();
        }

        public async Task<User> UpdateAsync(User user)
        {
            await usersTable.CreateIfNotExistsAsync();
            var tableEntity = new UserTableEntity(user);
            var updateOperation = TableOperation.Replace(tableEntity);
            var result = await usersTable.ExecuteAsync(updateOperation);

            return result.ToUser();
        }

        public async Task DeleteAsync(string username)
        {
            var tableEntity = new UserTableEntity(username);
            var retrieveOperation = TableOperation.Retrieve<UserTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await usersTable.ExecuteAsync(retrieveOperation);

            tableEntity = result.Result as UserTableEntity;

            var deleteOperation = TableOperation.Delete(tableEntity);
            await usersTable.ExecuteAsync(deleteOperation);
        }

        public Task<List<User>> ReadAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
