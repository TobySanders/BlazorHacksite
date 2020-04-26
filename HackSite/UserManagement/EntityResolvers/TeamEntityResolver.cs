using StorageProviders.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Abstractions.Models;

namespace UserManagement.EntityResolvers
{
    public class TeamEntityResolver : IEntityResolver<TeamTableEntity, Team>
    {
        public Team ToEntity(TeamTableEntity tableEntity)
        {
            return new Team
            {
                Id = tableEntity.Id,
                Name = tableEntity.Name,
                Projects = new List<Project>(),
                Members = new List<User>()
            };
        }

        public TeamTableEntity ToTableEntity(Team entity)
        {
            return new TeamTableEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                MemberIds = entity.Members.Select(p => p.Id).ToList(),
                ProjectIds = entity.Members.Select(p => p.Id).ToList()
            };
        }
    }
}
