using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageProviders.Mocks
{
    public class ProjectTableStorageMock : ITableStorageProvider<ProjectTableEntity, Guid>
    {
        private readonly ILogger<ProjectTableStorageMock> _logger;
        private readonly List<ProjectTableEntity> _projects;

        public ProjectTableStorageMock(ILogger<ProjectTableStorageMock> logger)
        {
            _projects = new List<ProjectTableEntity>
            {
                new ProjectTableEntity
                {
                        Id = Guid.Parse("891f1907-dbfc-461e-a67f-b52755da2251"),
                        Title = "A Test Project",
                        Description = "Making the world a better place",
                        RepositoryUrl = "http://notarealurl.com"
                },
                new ProjectTableEntity
                {
                        Id = Guid.Parse("891f1907-dbfc-461e-a67f-b52755da2252"),
                        Title = "Another Project",
                        Description = "I Do some things",
                        RepositoryUrl = "http://notarealurl.com"
                },
                new ProjectTableEntity
                {
                        Id = Guid.Parse("891f1907-dbfc-461e-a67f-b52755da2253"),
                        Title = "Yup it's a project",
                        Description = "Making the world a significantly worse place",
                        RepositoryUrl = "http://notarealurl.com"
                }
            };
        }

        public Task<ProjectTableEntity> CreateAsync(ProjectTableEntity model)
        {
            var Project = _projects.Find(p => p.Id == model.Id);

            if (Project == null)
            {
                model.Id = Guid.NewGuid();
                _projects.Add(model);
            }
            else
            {
                throw new Exception("Project already Exists");
            }

            return Task.FromResult(model);
        }

        public Task DeleteAsync(Guid key)
        {
            _projects.Remove(_projects.Find(p => p.Id == key));
            return Task.CompletedTask;
        }

        public Task<List<ProjectTableEntity>> ReadAllAsync()
        {
            return Task.FromResult(_projects);
        }

        public Task<ProjectTableEntity> ReadAsync(Guid key)
        {
            return Task.FromResult(_projects.Find(p => p.Id == key));
        }

        public Task<ProjectTableEntity> UpdateAsync(ProjectTableEntity model)
        {
            var user = _projects.Find(p => p.Id == model.Id);

            if (user != null)
            {
                _projects[_projects.IndexOf(user)] = model;
            }
            else
            {
                throw new Exception("User Not Found");
            }

            return Task.FromResult(model);
        }
    }
}
