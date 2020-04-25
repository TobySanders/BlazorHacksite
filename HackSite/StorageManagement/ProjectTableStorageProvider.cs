using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using StorageProviders.Abstractions.Settings;
using StorageProviders.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace StorageProviders
{
    public class ProjectTableStorageProvider : ITableStorageProvider<Project,Guid>
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

        public async Task<Project> CreateAsync(Project model)
        {
            await _projectsTable.CreateIfNotExistsAsync();
            var tableEntity = new ProjectTableEntity(model);
            var insertOperation = TableOperation.Insert(tableEntity);
            var result = await _projectsTable.ExecuteAsync(insertOperation);

            return result.ToProject();
        }

        public async Task<Project> ReadAsync(Guid Id)
        {
            await _projectsTable.CreateIfNotExistsAsync();

            var tableEntity = new ProjectTableEntity(Id);

            var retrieveOperation = TableOperation.Retrieve<ProjectTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await _projectsTable.ExecuteAsync(retrieveOperation);

            return result.ToProject();
        }

        public async Task<List<Project>> ReadAllAsync()
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

            return entities.Select(projectTableEntity => projectTableEntity.ToInternalModel()).ToList();
        }

        public async Task<Project> UpdateAsync(Project Project)
        {
            await _projectsTable.CreateIfNotExistsAsync();
            var tableEntity = new ProjectTableEntity(Project);
            var updateOperation = TableOperation.Replace(tableEntity);
            var result = await _projectsTable.ExecuteAsync(updateOperation);

            return result.ToProject();
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
