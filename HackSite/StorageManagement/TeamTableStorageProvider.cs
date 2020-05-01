using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using StorageProviders.Abstractions.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageProviders
{
    public class TeamTableStorageProvider : ITableStorageProvider<TeamTableEntity, Guid>
    {
        private readonly ILogger<TeamTableStorageProvider> _logger;
        private readonly TableSettings _tableSettings;

        private readonly CloudStorageAccount _cloudStorageAccount;
        private readonly CloudTableClient _cloudTableClient;
        private readonly CloudTable _teamsTable;
        public TeamTableStorageProvider(ILogger<TeamTableStorageProvider> logger, IOptions<TableSettings> tableSettings)
        {
            _logger = logger;
            _tableSettings = tableSettings.Value;

            _cloudStorageAccount = CloudStorageAccount.Parse(_tableSettings.ConnectionString);
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
            _teamsTable = _cloudTableClient.GetTableReference("Teams");
        }

        public async Task<TeamTableEntity> CreateAsync(TeamTableEntity team)
        {
            await _teamsTable.CreateIfNotExistsAsync();
            var insertOperation = TableOperation.Insert(team);
            var result = await _teamsTable.ExecuteAsync(insertOperation);

            return result.Result as TeamTableEntity;
        }

        public async Task<TeamTableEntity> ReadAsync(Guid Id)
        {
            await _teamsTable.CreateIfNotExistsAsync();

            var tableEntity = new TeamTableEntity(Id);

            var retrieveOperation = TableOperation.Retrieve<TeamTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await _teamsTable.ExecuteAsync(retrieveOperation);

            return result.Result as TeamTableEntity;
        }

        public async Task<List<TeamTableEntity>> ReadAllAsync()
        {
            await _teamsTable.CreateIfNotExistsAsync();

            var tableQuery = new TableQuery<TeamTableEntity>();
            var token = new TableContinuationToken();
            var entities = new List<TeamTableEntity>();

            do
            {
                var queryResult = await _teamsTable.ExecuteQuerySegmentedAsync(tableQuery, token);
                entities.AddRange(queryResult);
                token = queryResult.ContinuationToken;

            } while (token != null);

            return entities.Select(teamTableEntity => teamTableEntity).ToList();
        }

        public async Task<TeamTableEntity> UpdateAsync(TeamTableEntity team)
        {
            await _teamsTable.CreateIfNotExistsAsync();
            var updateOperation = TableOperation.Replace(team);
            var result = await _teamsTable.ExecuteAsync(updateOperation);

            return result.Result as TeamTableEntity;
        }

        public async Task DeleteAsync(Guid Id)
        {
            var tableEntity = new TeamTableEntity(Id);
            var retrieveOperation = TableOperation.Retrieve<TeamTableEntity>(tableEntity.PartitionKey, tableEntity.RowKey);
            var result = await _teamsTable.ExecuteAsync(retrieveOperation);

            tableEntity = result.Result as TeamTableEntity;

            var deleteOperation = TableOperation.Delete(tableEntity);
            await _teamsTable.ExecuteAsync(deleteOperation);
        }
    }
}
