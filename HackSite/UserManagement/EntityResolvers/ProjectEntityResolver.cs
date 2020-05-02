﻿using StorageProviders.Abstractions.Models;
using UserManagement.Abstractions.Models;

namespace UserManagement.EntityResolvers
{
    public class ProjectEntityResolver : IEntityResolver<ProjectTableEntity, Project>
    {
        public Project ToTargetType(ProjectTableEntity tableEntity)
        {
            return new Project
            {
                Id = tableEntity.Id,
                Title = tableEntity.Title,
                Description = tableEntity.Description,
                RepositoryUrl = tableEntity.RepositoryUrl
            };
        }

        public ProjectTableEntity ToSourceType(Project entity)
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
