using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Mocks
{
    public class ProjectTableStorageMock : ITableStorageProvider<Project, Guid>
    {
        private readonly ILogger<ProjectTableStorageMock> _logger;
        private readonly List<Project> _projects;

        public ProjectTableStorageMock(ILogger<ProjectTableStorageMock> logger)
        {
            _projects = new List<Project>
            {
                new Project
                {
                        Id = Guid.Parse("ac77d3ae-15d1-4d53-9026-fa91eb203268"),
                        Title = "A Test Project",
                        Description = "Making the world a better place",
                        GithubUrl = "http://notarealurl.com"

                }
            };
        }

        public Task<Project> CreateAsync(Project model)
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

        public Task<List<Project>> ReadAllAsync()
        {
            return Task.FromResult(_projects);
        }

        public Task<Project> ReadAsync(Guid key)
        {
            return Task.FromResult(_projects.Find(p => p.Id == key));
        }

        public Task<Project> UpdateAsync(Project model)
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
