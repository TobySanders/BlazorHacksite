using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HackSite.Views
{
    public class CreateTeamView
    {
        [Required (ErrorMessage = "Team must have a name" )]
        [StringLength(24, ErrorMessage = "Team name must be less than 24 characters")]
        public string Name { get; set; }

        public List<Guid> ProjectIds { get; set; }
        public List<Guid> MemberIds { get; set; }

        public CreateTeamView()
        {
            ProjectIds = new List<Guid>();
            MemberIds = new List<Guid>();
        }
    }
}
