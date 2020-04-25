using System;
using System.Collections.Generic;

namespace HackSite.Data
{
    public class TeamView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProjectView> Project { get; set; }
        public List<UserView> Members { get; set; }
    }
}
