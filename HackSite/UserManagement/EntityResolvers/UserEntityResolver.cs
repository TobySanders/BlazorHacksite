using StorageProviders.Abstractions.Models;
using UserManagement.Abstractions.Models;

namespace UserManagement.EntityResolvers
{
    public class UserEntityResolver : IEntityResolver<UserTableEntity, User>
    {
        public User ToEntity(UserTableEntity tableEntity)
        {
            return new User
            {
                Id = tableEntity.Id,
                Username = tableEntity.Username
            };
        }

        public UserTableEntity ToTableEntity(User entity)
        {
            return new UserTableEntity
            {
                Id = entity.Id,
                Username = entity.Username
            };
        }
    }
}
