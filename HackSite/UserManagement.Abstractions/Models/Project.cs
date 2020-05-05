using System;

namespace UserManagement.Abstractions.Models
{
    public class Project : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }

        public Guid Key => Id;
    }
}
