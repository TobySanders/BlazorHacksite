using System;
using System.Collections.Generic;

namespace UserManagement.Abstractions.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
        public List<Project> Projects { get; set; }
    }
}
