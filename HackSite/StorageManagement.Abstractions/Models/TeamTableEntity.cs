using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Abstractions.Models
{
    public class TeamTableEntity : TableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> MemberNames { get; set; }
        public List<Guid> ProjectIds { get; set; }

        #region constructors

        //needed for queries
        public TeamTableEntity()
        {

        }
        public TeamTableEntity(Guid id)
        {
            Id = id;

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        public TeamTableEntity(string name)
        {
            Name = name;
            Id = Guid.NewGuid();

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        public TeamTableEntity(Team team)
        {
            Id = team.Id;
            Name = team.Name;

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        public TeamTableEntity(Team team, List<string> memberNames)
        {
            Id = team.Id;
            Name = team.Name;
            MemberNames = memberNames;

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        public TeamTableEntity(Team team, List<Guid> projectIds)
        {
            Id = team.Id;
            Name = team.Name;
            ProjectIds = projectIds;

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        public TeamTableEntity(Team team, List<string> memberNames, List<Guid> projectIds)
        {
            Id = team.Id;
            Name = team.Name;
            MemberNames = memberNames;
            ProjectIds = projectIds;

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        #endregion
    }
}
