using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System;
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
    }
}
