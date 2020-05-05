using System;
using System.Collections.Generic;

namespace HackSite.Views
{
    public class CreateTeamView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> ProjectIds { get; set; }
        public List<Guid> MemberIds { get; set; }
    }
}
