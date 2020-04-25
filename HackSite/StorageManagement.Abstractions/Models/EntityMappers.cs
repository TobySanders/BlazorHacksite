using StorageProviders.Abstractions.Models;

namespace UserManagement.Abstractions.Models
{
    public static class EntityMappers
    {
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

        public static Team ToInternalModel(this TeamTableEntity entity)
        {
            return new Team
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
