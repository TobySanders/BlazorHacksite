using Microsoft.WindowsAzure.Storage.Table;
using StorageProviders.Abstractions.Models;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Extensions
{
    public static class EntityMappers
    {
        public static User ToUser(this TableResult result)
        {
            var userEntity = result.Result as UserTableEntity;
            return userEntity.ToInternalModel();
        }

        public static Project ToProject(this TableResult result)
        {
            var tableEntity = result.Result as ProjectTableEntity;
            return tableEntity.ToInternalModel();
        }

        public static Project ToInternalModel(this ProjectTableEntity entity)
        {
            return new Project
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                GithubUrl = entity.GithubUrl
            };
        }

        public static User ToInternalModel(this UserTableEntity entity)
        {
            return new User
            {
                Username = entity.Username,
            };
        }
    }
}
