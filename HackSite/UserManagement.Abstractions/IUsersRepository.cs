using System;
using UserManagement.Abstractions.Models;

namespace UserManagement.Abstractions
{
    public interface IUsersRepository : IRepository<User, Guid>
    {
    }
}
