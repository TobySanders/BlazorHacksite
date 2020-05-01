using System;
using UserManagement.Abstractions.Models;

namespace UserManagement.Abstractions
{
    public interface IProjectsRepository : IRepository<Project, Guid>
    {
    }
}
