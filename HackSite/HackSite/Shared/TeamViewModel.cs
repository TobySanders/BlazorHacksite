using System.Collections.Generic;

namespace HackSite.Shared
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }
        public ProjectViewModel Project { get; set; }
    }
}
