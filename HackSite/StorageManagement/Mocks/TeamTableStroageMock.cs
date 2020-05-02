using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageProviders.Mocks
{
    public class TeamTableStroageMock : ITableStorageProvider<TeamTableEntity, Guid>
    {
        private readonly ILogger<TeamTableStroageMock> _logger;
        private readonly List<TeamTableEntity> _teams;

        public TeamTableStroageMock(ILogger<TeamTableStroageMock> logger)
        {
            _teams = new List<TeamTableEntity>
            {
                new TeamTableEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Team 0",
                    ProjectIds = new List<Guid>
                    {
                        Guid.Parse("891f1907-dbfc-461e-a67f-b52755da2251")
                    },
                    MemberIds = new List<Guid>
                    {
                        Guid.Parse("5d8bce36-4f42-4078-bb16-e4dda6754de1"),
                        Guid.Parse("5d26f61c-bd79-45ed-a260-de85d9db7d1a")
                    }
                }
            };
        }

        public Task<TeamTableEntity> CreateAsync(TeamTableEntity model)
        {
            var team = _teams.Find(p => p.Name == model.Name);

            model.Id = Guid.NewGuid();
            _teams.Add(model);

            return Task.FromResult(model);
        }

        public Task DeleteAsync(Guid key)
        {
            _teams.Remove(_teams.Find(p => p.Id == key));
            return Task.CompletedTask;
        }

        public Task<List<TeamTableEntity>> ReadAllAsync()
        {
            return Task.FromResult(_teams);
        }

        public Task<TeamTableEntity> ReadAsync(Guid key)
        {
            return Task.FromResult(_teams.Find(p => p.Id == key));
        }

        public Task<TeamTableEntity> UpdateAsync(TeamTableEntity model)
        {
            var team = _teams.Find(p => p.Id == model.Id);

            if (team != null)
            {
                _teams[_teams.IndexOf(team)] = model;
            }
            else
            {
                throw new Exception("Team Not Found");
            }

            return Task.FromResult(model);
        }
    }
}
