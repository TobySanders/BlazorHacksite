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

        public async Task<Project> AddProjectAsync(Project project)
        {
            return await _tableStorageProvider.CreateAsync(project);
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await _tableStorageProvider.DeleteAsync(id);
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _tableStorageProvider.ReadAllAsync();
        }

        public async Task<List<Project>> GetAllProjectsAsync(Guid teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetAllProjectsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetProjectAsync(Guid id)
        {
            return await _tableStorageProvider.ReadAsync(id);
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            return await _tableStorageProvider.UpdateAsync(project);
        }
    }
}
