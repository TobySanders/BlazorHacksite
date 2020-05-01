using System;
using System.Collections.Generic;

namespace HackSite.Views
{
    public class TeamView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProjectView> Projects { get; set; }
        public List<UserView> Members { get; set; }
    }
}
