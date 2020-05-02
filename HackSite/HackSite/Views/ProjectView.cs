using System;

namespace HackSite.Views
{
    public class ProjectView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
    }
}
