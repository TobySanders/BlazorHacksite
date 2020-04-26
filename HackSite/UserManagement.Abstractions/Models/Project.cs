using System;

namespace UserManagement.Abstractions.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public string ProjectImage { get; set; } //base64
        public string ShortCode { get; set; } //For sharing
        public bool IsActive { get; set; }
    }
}
