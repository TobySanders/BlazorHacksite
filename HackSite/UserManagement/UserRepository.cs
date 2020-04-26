using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class UserRepository : Repository<User, UserTableEntity, Guid>, IUsersRepository
    {
        private readonly ITableStorageProvider<UserTableEntity, Guid> _tableStorageProvider;
        private readonly IEntityResolver<UserTableEntity, User> _entityResolver;

        public UserRepository(ITableStorageProvider<UserTableEntity, Guid> tableStorageProvider, IEntityResolver<UserTableEntity, User> entityResolver)
            : base(tableStorageProvider, entityResolver)
        {
            _tableStorageProvider = tableStorageProvider;
        }
    }
}
