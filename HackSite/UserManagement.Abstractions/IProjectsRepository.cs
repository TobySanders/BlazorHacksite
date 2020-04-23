using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace UserManagement.Abstractions
{
    public interface IProjectsRepository
    {
        Task<Project> AddProject(Project project);
        Task<Project> GetProject(Guid id);
        Task<List<Project>> GetAllProjects();
        /// <summary>
        /// Gets all Projects for a given team
        /// </summary>
        /// <param name="teamId">Id for the team</param>
        Task<List<Project>> GetAllProjects(Guid teamId);
        /// <summary>
        /// Gets all projects for a given username
        /// </summary>
        Task<List<Project>> GetAllProjects(string username);
        Task<Project> UpdateProject(Project project);
        Task DeleteProject(Guid id);
    }
}
