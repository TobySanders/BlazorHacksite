using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ITableStorageProvider<Project,Guid> _tableStorageProvider;
        private readonly ILogger<ProjectsRepository> _logger;

        public ProjectsRepository(ITableStorageProvider<Project,Guid> tableStorageProvider, ILogger<ProjectsRepository> logger)
        {
            _tableStorageProvider = tableStorageProvider;
            _logger = logger;
        }

        public async Task<Project> AddProject(Project project)
        {
            return await _tableStorageProvider.CreateAsync(project);
        }

        public async Task DeleteProject(Guid id)
        {
            await _tableStorageProvider.DeleteAsync(id);
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _tableStorageProvider.ReadAllAsync();
        }

        public async Task<List<Project>> GetAllProjects(Guid teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetAllProjects(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetProject(Guid id)
        {
            return await _tableStorageProvider.ReadAsync(id);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            return await _tableStorageProvider.UpdateAsync(project);
        }
    }
}
