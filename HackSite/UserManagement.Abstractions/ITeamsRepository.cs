using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace UserManagement.Abstractions
{
    public interface ITeamsRepository : IRepository<Team,Guid>
    {
        Task<List<Team>> GetAllTeamsByUserAsync(Guid userId, bool descending = false);
        Task<List<Team>> GetAllTeamsByProjectAsync(Guid projectId, bool descending = false);
    }
}
