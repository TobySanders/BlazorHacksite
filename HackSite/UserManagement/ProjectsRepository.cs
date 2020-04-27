using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class ProjectsRepository : Repository<Project, ProjectTableEntity,Guid>, IProjectsRepository
    {
        private readonly ITableStorageProvider<ProjectTableEntity,Guid> _tableStorageProvider;
        private readonly ILogger<ProjectsRepository> _logger;

        public ProjectsRepository(ITableStorageProvider<ProjectTableEntity, Guid> tableStorageProvider, IEntityResolver<ProjectTableEntity, Project> entityResolver, ILogger<ProjectsRepository> logger)
            : base(tableStorageProvider, entityResolver)
        {
            _tableStorageProvider = tableStorageProvider;
            _logger = logger;
        }

        public Task<List<Project>> GetProjectsByTeamAsync(Guid teamId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetProjectsByUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
