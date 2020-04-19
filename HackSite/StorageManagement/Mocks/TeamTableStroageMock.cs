using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Mocks
{
    public class TeamTableStroageMock : ITableStorageProvider<Team>
    {
        private readonly ILogger<TeamTableStroageMock> _logger;
        private readonly List<Team> _teams;

        public TeamTableStroageMock(ILogger<TeamTableStroageMock> logger)
        {
            _teams = new List<Team>
            {
                new Team
                {
                    Id = 0,
                    Name = "Test Team 0",
                    project = new Project
                    {
                        Id = 0,
                        Title = "A Test Project",
                        Description = "Making the world a better place",
                        GithubUrl = "http://notarealurl.com"
                    }
                }
            };
        }

        public Task<Team> CreateAsync(Team model)
        {
            var team = _teams.Find(p => p.Name == model.Name);

            if (team == null)
            {
                model.Id = _teams.Count;
                _teams.Add(model);
            }
            else
            {
                throw new Exception("Team already Exists");
            }

            return Task.FromResult(model);
        }

        public Task DeleteAsync(string key)
        {
            _teams.Remove(_teams.Find(p => p.Name == key));
            return Task.CompletedTask;
        }

        public Task<List<Team>> ReadAllAsync()
        {
            return Task.FromResult(_teams);
        }

        public Task<Team> ReadAsync(string key)
        {
            return Task.FromResult(_teams.Find(p => p.Name == key));
        }

        public Task<Team> UpdateAsync(Team model)
        {
            var user = _teams.Find(p => p.Name == model.Name);

            if (user != null)
            {
                _teams[_teams.IndexOf(user)] = model;
            }
            else
            {
                throw new Exception("User Not Found");
            }

            return Task.FromResult(model);
        }
    }
}
