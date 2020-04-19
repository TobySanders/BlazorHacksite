using System;
using System.Collections.Generic;
using System.Text;

namespace HackSite.Shared
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GithubUrl { get; set; }
    }
}
