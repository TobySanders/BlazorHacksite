using StorageProviders.Abstractions.Models;
using System;
using UserManagement.Abstractions.Models;

namespace UserManagement.EntityResolvers
{
    public class UserEntityResolver : IEntityResolver<UserTableEntity, User>
    {
        public User ToTargetType(UserTableEntity tableEntity)
        {
            return new User
            {
                Id = tableEntity.Id,
                Username = tableEntity.Username
            };
        }

        public UserTableEntity ToSourceType(User entity)
        {
            return new UserTableEntity
            {
                Id = entity.Id == Guid.Empty ? Guid.NewGuid() : entity.Id,
                Username = entity.Username
            };
        }
    }
}
