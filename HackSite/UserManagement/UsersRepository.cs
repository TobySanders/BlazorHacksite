using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class UsersRepository : Repository<User, UserTableEntity, Guid>, IUsersRepository
    {
        public UsersRepository(ITableStorageProvider<UserTableEntity, Guid> tableStorageProvider, IEntityResolver<UserTableEntity, User> entityResolver)
            : base(tableStorageProvider, entityResolver)
        {
        }
    }
}
