using StorageProviders.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class UserRepository : IUserRepository
    {
        private readonly ITableStorageProvider<User> _tableStorageProvider;
        private readonly IFileStorageProvider _blobStorageProvider;
        public UserRepository(ITableStorageProvider<User> tableStorageProvider, IFileStorageProvider blobStorageProvider)
        {
            _tableStorageProvider = tableStorageProvider;
            _blobStorageProvider = blobStorageProvider;
        }

        public async Task<User> CreateUserAsync(string username)
        {
            var blobKey = await  _blobStorageProvider.CreateStorageAsync(username);

            var user = new User
            {
                Username = username,
                StroageAddress = blobKey
            };
            return await _tableStorageProvider.CreateAsync(user);
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _tableStorageProvider.ReadAsync(username);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
