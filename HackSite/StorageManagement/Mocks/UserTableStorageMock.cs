using Microsoft.Extensions.Logging;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageProviders.Mocks
{
    public class UserTableStorageMock : ITableStorageProvider<UserTableEntity, Guid>
    {
        private readonly ILogger<UserTableStorageMock> _logger;
        private readonly List<UserTableEntity> _users;

        public UserTableStorageMock(ILogger<UserTableStorageMock> logger)
        {
            _logger = logger;
            _users = new List<UserTableEntity>
            {
               new UserTableEntity
               {
                   Id = Guid.Parse("5d8bce36-4f42-4078-bb16-e4dda6754de1"),
                   Username = "User_0",
               },
               new UserTableEntity
               {
                   Id = Guid.Parse("5d26f61c-bd79-45ed-a260-de85d9db7d1a"),
                   Username = "User_1"
               }
            };
        }

        public Task<UserTableEntity> CreateAsync(UserTableEntity model)
        {
            var user = _users.Find(p => p.Username == model.Username);

            if (user == null)
            {
                model.Id = Guid.NewGuid();
                _users.Add(model);
            }
            else
            {
                throw new Exception("User already Exists");
            }

            return Task.FromResult(model);
        }

        public Task DeleteAsync(Guid key)
        {
            _users.Remove(_users.Find(p => p.Id == key));
            return Task.CompletedTask;
        }

        public Task<UserTableEntity> ReadAsync(Guid key)
        {
            return Task.FromResult(_users.Find(p => p.Id == key));
        }

        public Task<List<UserTableEntity>> ReadAllAsync()
        {
            return Task.FromResult(_users);
        }
        public Task<UserTableEntity> UpdateAsync(UserTableEntity model)
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
