using HackSite.Mappers;
using HackSite.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace HackSite.Controllers
{
    public class TeamsController
    {
        private readonly ITeamsRepository _teamRepository;

        public TeamsController(ITeamsRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamView> AddTeamAsync(CreateTeamView teamView)
        {
            var team = new Team
            {
                Name = teamView.Name,
                Members = teamView.MemberIds.Select(memberId=>new User{Id = memberId}).ToList(),
                Projects = teamView.ProjectIds.Select(memberId => new Project { Id = memberId }).ToList()
            };

            var result = await _teamRepository.CreateAsync(team);
            return result.Map();
        }

        public async Task<TeamView[]> GetTeamsAsync()
        {
            var result = await _teamRepository.ReadAllAsync();
            return result.Select(team => team.Map()).ToArray();
        }

        public async Task<TeamView> GetTeamAsync(Guid teamId)
        {
            var result = await _teamRepository.ReadAsync(teamId);
            return result.Map();
        }

        public async Task<TeamView[]> GetTeamsByProjectAsync(Guid projectId)
        {
            var result = await _teamRepository.GetAllTeamsByProjectAsync(projectId);
            return result.Select(team => team.Map()).ToArray();
        }

        public async Task<TeamView[]> GetTeamsByUserAsync(Guid userId)
        {
            var result = await _teamRepository.GetAllTeamsByUserAsync(userId);
            return result.Select(team => team.Map()).ToArray();
        }

        public async Task<TeamView> UpdateTeamAsync(TeamView teamView)
        {
            var team = teamView.Map();
            var result = await _teamRepository.UpdateAsync(team);
            return result.Map();
        }

        public async Task DeleteAsync(Guid teamId)
        {
            await _teamRepository.DeleteAsync(teamId);
        }
    }
}
