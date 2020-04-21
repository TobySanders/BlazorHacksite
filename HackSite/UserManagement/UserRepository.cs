using StorageProviders.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace UserManagement
{
    public class UserRepository : IUserRepository
    {
        private readonly ITableStorageProvider<User, string> _tableStorageProvider;

        public UserRepository(ITableStorageProvider<User, string> tableStorageProvider)
        {
            _tableStorageProvider = tableStorageProvider;
        }

        public async Task<User> CreateUserAsync(string username)
        {

            var user = new User
            {
                Username = username,
            };

            return await _tableStorageProvider.CreateAsync(user);
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _tableStorageProvider.ReadAsync(username);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _tableStorageProvider.ReadAllAsync();
        }
    }
}
