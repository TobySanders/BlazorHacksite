using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace UserManagement.Abstractions
{
    public interface IProjectsRepository
    {
        Task<Project> AddProjectAsync(Project project);
        Task<Project> GetProjectAsync(Guid id);
        Task<List<Project>> GetAllProjectsAsync();
        /// <summary>
        /// Gets all Projects for a given team
        /// </summary>
        /// <param name="teamId">Id for the team</param>
        Task<List<Project>> GetAllProjectsAsync(Guid teamId);
        /// <summary>
        /// Gets all projects for a given username
        /// </summary>
        Task<List<Project>> GetAllProjectsAsync(string username);
        Task<Project> UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Guid id);
    }
}
