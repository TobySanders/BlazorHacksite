using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using StorageProviders.Abstractions.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageProviders
{
    public class UserTableStorageProvider : ITableStorageProvider<UserTableEntity, Guid>
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

        public async Task<UserTableEntity> CreateAsync(UserTableEntity entity)
        {
            await usersTable.CreateIfNotExistsAsync();
            var insertOperation = TableOperation.Insert(entity);
            var result = await usersTable.ExecuteAsync(insertOperation);

            return result.Result as UserTableEntity;
        }

        public async Task<UserTableEntity> ReadAsync(Guid userId)
        {
            await usersTable.CreateIfNotExistsAsync();

            var tableEntity = new UserTableEntity(userId);

            var retrieveOperation = TableOperation.Retrieve<UserTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await usersTable.ExecuteAsync(retrieveOperation);

            return result.Result as UserTableEntity;
        }

        public async Task<UserTableEntity> UpdateAsync(UserTableEntity entity)
        {
            await usersTable.CreateIfNotExistsAsync();
            var updateOperation = TableOperation.Replace(entity);
            var result = await usersTable.ExecuteAsync(updateOperation);

            return result.Result as UserTableEntity;
        }

        public async Task DeleteAsync(Guid userId)
        {
            var tableEntity = new UserTableEntity(userId);
            var retrieveOperation = TableOperation.Retrieve<UserTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await usersTable.ExecuteAsync(retrieveOperation);

            tableEntity = result.Result as UserTableEntity;

            var deleteOperation = TableOperation.Delete(tableEntity);
            await usersTable.ExecuteAsync(deleteOperation);
        }

        public Task<List<UserTableEntity>> ReadAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
