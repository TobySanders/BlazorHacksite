using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Abstractions.Models
{
    public class TeamTableEntity : TableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [IgnoreProperty]
        public List<Guid> MemberIds { get; set; }
        [IgnoreProperty]
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
            Id = team.Id == Guid.Empty ? Guid.NewGuid() : team.Id; ;
            Name = team.Name;
            MemberIds = team.Members.Select(m => m.Id).ToList();
            ProjectIds = team.Projects.Select(m => m.Id).ToList();

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        public TeamTableEntity(Team team, List<Guid> memberIds, List<Guid> projectIds)
        {
            Id = team.Id;
            Name = team.Name;
            MemberIds = memberIds;
            ProjectIds = projectIds;

            PartitionKey = "0"; //going to use static partitioning to reduce complexity given the scale
            RowKey = Id.ToString();
        }

        #endregion

        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            // This line will write partition key and row key, but not Layout since it has the IgnoreProperty attribute
            var x = base.WriteEntity(operationContext);

            // Writing x manually as a serialized string.
            x[nameof(MemberIds)] = new EntityProperty(JsonConvert.SerializeObject(MemberIds));
            x[nameof(ProjectIds)] = new EntityProperty(JsonConvert.SerializeObject(ProjectIds));
            return x;
        }

        public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            base.ReadEntity(properties, operationContext);
            if (properties.ContainsKey(nameof(MemberIds)))
            {
                MemberIds = JsonConvert.DeserializeObject<List<Guid>>(properties[nameof(MemberIds)].StringValue);
            }
            if (properties.ContainsKey(nameof(ProjectIds)))
            {
                ProjectIds = JsonConvert.DeserializeObject<List<Guid>>(properties[nameof(ProjectIds)].StringValue);
            }
        }
    }
}
