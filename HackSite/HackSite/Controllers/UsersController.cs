using HackSite.Mappers;
using HackSite.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace HackSite.Controllers
{
    public class UsersController
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<UserView> AddUserAsync(CreateUserView userView)
        {
            var user = new User
            {
                Username = userView.Username
            };
            var result = await _usersRepository.CreateAsync(user);
            return result.Map();
        }

        public async Task<UserView> GetUserAsync(Guid id)
        {
            var result = await _usersRepository.ReadAsync(id);
            return result.Map();
        }

        public async Task<UserView[]> GetUsersAsync()
        {
            var result = await _usersRepository.ReadAllAsync();
            return result.Select(user => user.Map()).ToArray();
        }

        public async Task<UserView> UpdateUserAsync(UserView userView)
        {
            var user = new User
            {
                Id = userView.Id,
                Username = userView.Username
            };
            var result = await _usersRepository.UpdateAsync(user);
            return result.Map();
        }

        public async Task DeleteAsync(Guid userId)
        {
            await _usersRepository.DeleteAsync(userId);
        }
    }
}
