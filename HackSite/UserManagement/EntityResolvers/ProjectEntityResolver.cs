using StorageProviders.Abstractions.Models;
using UserManagement.Abstractions.Models;

namespace UserManagement.EntityResolvers
{
    public class ProjectEntityResolver : IEntityResolver<ProjectTableEntity, Project>
    {
        public Project ToEntity(ProjectTableEntity tableEntity)
        {
            return new Project
            {
                Id = tableEntity.Id,
                Title = tableEntity.Title,
                Description = tableEntity.Description,
                RepositoryUrl = tableEntity.RepositoryUrl
            };
        }

        public ProjectTableEntity ToTableEntity(Project entity)
        {
            return new ProjectTableEntity
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                RepositoryUrl = entity.RepositoryUrl
            };
        }
    }
}
