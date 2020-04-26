using System;
using System.Collections.Generic;

namespace UserManagement.Abstractions.Models
{
    public class Team : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
        public List<Project> Projects { get; set; }

        public Guid Key => Id;
    }
}
