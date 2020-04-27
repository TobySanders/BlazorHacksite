using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace UserManagement.Abstractions
{
    public interface IProjectsRepository : IRepository<Project, Guid>
    {
        Task<List<Project>> GetProjectsByTeamAsync(Guid teamId);
        Task<List<Project>> GetProjectsByUserAsync(Guid userId);
    }
}
