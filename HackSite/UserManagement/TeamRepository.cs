using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ILogger<TeamRepository> _logger;
        private readonly ITableStorageProvider<Team, string> _tableStorageProvider;

        public TeamRepository(ILogger<TeamRepository> logger, ITableStorageProvider<Team, string> tableStorageProvider)
        {
            _logger = logger;
            _tableStorageProvider = tableStorageProvider;
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            var result = await _tableStorageProvider.CreateAsync(team);
            return result;
        }

        public async Task<Team> GetTeamAsync(string name)
        {
            var result = await _tableStorageProvider.ReadAsync(name);
            return result;        
        }

        public async Task<List<Team>> GetTeamsAsync()
        {
            var result = await _tableStorageProvider.ReadAllAsync();
            return result;
        }
    }
}
