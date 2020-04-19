using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace UserManagement.Abstractions
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamAsync(string name);
        Task<List<Team>> GetTeamsAsync();
        Task<Team> CreateTeamAsync(Team team);
    }
}
