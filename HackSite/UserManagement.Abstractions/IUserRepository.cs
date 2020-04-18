using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions.Models;

namespace UserManagement.Abstractions
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username);
        Task<List<User>> GetUsersAsync();
        Task<User> CreateUserAsync(string username);
    }
}
