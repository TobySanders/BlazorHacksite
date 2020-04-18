using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace StorageProviders.Mocks
{
    public class UserTableStorageMock : ITableStorageProvider<User>
    {
        private readonly ILogger<UserTableStorageMock> _logger;
        private readonly List<User> _users;

        public UserTableStorageMock(ILogger<UserTableStorageMock> logger)
        {
            _logger = logger;
            _users = new List<User>
            {
               new User
               {
                   Username = "Test User 1",
               },
               new User
               {
                   Username = "Test User 2"
               }
            };
        }

        public Task<User> CreateAsync(User model)
        {
            var user = _users.Find(p => p.Username == model.Username);

            if (user == null)
            {
                _users.Add(model);
            }
            else
            {
                throw new Exception("User already Exists");
            }

            return Task.FromResult(model);
        }

        public Task DeleteAsync(string key)
        {
            _users.Remove(_users.Find(p => p.Username == key));
            return Task.CompletedTask;
        }

        public Task<User> ReadAsync(string key)
        {
            return Task.FromResult(_users.Find(p => p.Username == key));
        }

        public Task<List<User>> ReadAllAsync()
        {
            return Task.FromResult(_users);
        }
        public Task<User> UpdateAsync(User model)
        {
            var user = _users.Find(p => p.Username == model.Username);
            
            if(user != null)
            {
                _users[_users.IndexOf(user)] = model;
            }
            else
            {
                throw new Exception("User Not Found");
            }

            return Task.FromResult(model);
        }
    }
}
