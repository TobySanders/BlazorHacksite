using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class TeamsRepository : Repository<Team, TeamTableEntity, Guid>, ITeamsRepository
    {
        private readonly ITableStorageProvider<TeamTableEntity, Guid> _teamTableStorageProvider;
        private readonly IProjectsRepository _projectsRepository;
        private readonly IUsersRepository _usersRepository;

        public TeamsRepository(ILogger<TeamsRepository> logger, ITableStorageProvider<TeamTableEntity, Guid> teamTableStorageProvider,
            IProjectsRepository projectsRepository, IUsersRepository userRepository, IEntityResolver<TeamTableEntity,Team> entityResolver) 
            : base(teamTableStorageProvider, entityResolver)
        {
            _teamTableStorageProvider = teamTableStorageProvider;
            _projectsRepository = projectsRepository;
            _usersRepository = userRepository;
        }
        public override async Task<Team> ReadAsync(Guid key)
        {
            var tableResult = await _teamTableStorageProvider.ReadAsync(key);

            return await MapTeam(tableResult);
        }

        public override async Task<List<Team>> ReadAllAsync(bool descending = false)
        {
            var tableResult = await _teamTableStorageProvider.ReadAllAsync();
            var mappedTeams = await MapTeams(tableResult);

            return OrderByDefault(mappedTeams, descending);
        }

        public async Task<List<Team>> GetAllTeamsByProjectAsync(Guid key, bool descending = false)
        {
            var tableResult = await _teamTableStorageProvider.ReadAllAsync();
            var filterResult = tableResult.Where(p => p.ProjectIds.Contains(key)).ToList();
            var mappedTeams = await MapTeams(filterResult);

            return OrderByDefault(mappedTeams, descending);
        }

        public async Task<List<Team>> GetAllTeamsByUserAsync(Guid userId, bool descending = false)
        {
            var tableResult = await _teamTableStorageProvider.ReadAllAsync();
            var filterResult = tableResult.Where(p => p.MemberIds.Contains(userId)).ToList();
            var mappedTeams = await MapTeams(filterResult);

            return OrderByDefault(mappedTeams, descending);
        }

        private async Task<Team> MapTeam(TeamTableEntity tableResult)
        {
            return new Team
            {
                Id = tableResult.Id,
                Name = tableResult.Name,
                Projects = await _projectsRepository.ReadMultipleAsync(tableResult.ProjectIds),
                Members = await _usersRepository.ReadMultipleAsync(tableResult.MemberIds)
            };
        }

        private async Task<List<Team>> MapTeams(List<TeamTableEntity> tableResult)
        {
            var tasks = new List<Task<Team>>();

            foreach (var tableEntity in tableResult)
            {
                tasks.Add(MapTeam(tableEntity));
            }
            return (await Task.WhenAll(tasks)).ToList();
        }

        protected override List<Team> OrderByDefault(List<Team> entities, bool descending)
        {
            return entities.OrderBy(p => p.Name).ToList();
        }
    }
}
