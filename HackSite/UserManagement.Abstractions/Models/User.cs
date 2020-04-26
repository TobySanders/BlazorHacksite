using System;
using System.Collections.Generic;

namespace UserManagement.Abstractions.Models
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public Guid Key => Id;
    }
}
