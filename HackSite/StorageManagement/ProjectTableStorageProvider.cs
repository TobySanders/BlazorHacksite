using Microsoft.Extensions.Logging;
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
    public class ProjectTableStorageProvider : ITableStorageProvider<ProjectTableEntity, Guid>
    {
        private readonly ILogger<ProjectTableStorageProvider> _logger;
        private readonly TableSettings _tableSettings;

        private readonly CloudStorageAccount _cloudStorageAccount;
        private readonly CloudTableClient _cloudTableClient;
        private readonly CloudTable _projectsTable;

        public ProjectTableStorageProvider(ILogger<ProjectTableStorageProvider> logger, IOptions<TableSettings> tableSettings)
        {
            _logger = logger;
            _tableSettings = tableSettings.Value;

            _cloudStorageAccount = CloudStorageAccount.Parse(_tableSettings.ConnectionString);
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
            _projectsTable = _cloudTableClient.GetTableReference("Projects");
        }

        public async Task<ProjectTableEntity> CreateAsync(ProjectTableEntity entity)
        {
            await _projectsTable.CreateIfNotExistsAsync();
            var insertOperation = TableOperation.Insert(entity);
            var result = await _projectsTable.ExecuteAsync(insertOperation);

            var projectTableEntity = result.Result as ProjectTableEntity;
            return projectTableEntity;
        }

        public async Task<ProjectTableEntity> ReadAsync(Guid Id)
        {
            await _projectsTable.CreateIfNotExistsAsync();

            var tableEntity = new ProjectTableEntity(Id);

            var retrieveOperation = TableOperation.Retrieve<ProjectTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await _projectsTable.ExecuteAsync(retrieveOperation);

            var projectTableEntity = result.Result as ProjectTableEntity;
            return projectTableEntity;
        }

        public async Task<List<ProjectTableEntity>> ReadAllAsync()
        {
            await _projectsTable.CreateIfNotExistsAsync();

            var tableQuery = new TableQuery<ProjectTableEntity>();
            var token = new TableContinuationToken();
            var entities = new List<ProjectTableEntity>();

            do
            {
                var queryResult = await _projectsTable.ExecuteQuerySegmentedAsync(tableQuery, token);
                entities.AddRange(queryResult);
                token = queryResult.ContinuationToken;

            } while (token != null);

            return entities;
        }

        public async Task<ProjectTableEntity> UpdateAsync(ProjectTableEntity entity)
        {
            await _projectsTable.CreateIfNotExistsAsync();
            var updateOperation = TableOperation.Replace(entity);
            var result = await _projectsTable.ExecuteAsync(updateOperation);

            var projectTableEntity = result.Result as ProjectTableEntity;
            return projectTableEntity;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var tableEntity = new ProjectTableEntity(Id);
            var retrieveOperation = TableOperation.Retrieve<ProjectTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await _projectsTable.ExecuteAsync(retrieveOperation);

            tableEntity = result.Result as ProjectTableEntity;

            var deleteOperation = TableOperation.Delete(tableEntity);
            await _projectsTable.ExecuteAsync(deleteOperation);
        }
    }
}
