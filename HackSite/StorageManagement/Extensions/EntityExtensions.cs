using Microsoft.WindowsAzure.Storage.Table;
using StorageProviders.Abstractions.Models;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Extensions
{
    public static class EntityExtensions
    {
        public static Project ToProject(this TableResult result)
        {
            var tableEntity = result.Result as ProjectTableEntity;
            return tableEntity.ToInternalModel();
        }

        public static User ToUser(this TableResult result)
        {
            var userEntity = result.Result as UserTableEntity;
            return userEntity.ToInternalModel();
        }

        public static TeamTableEntity ToTeam(this TableResult result)
        {
            var tableEntity = result.Result as TeamTableEntity;
            return tableEntity;
        }
    }
}
