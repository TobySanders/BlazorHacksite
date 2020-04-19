using System.Collections.Generic;

namespace UserManagement.Abstractions.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }
        public Project project { get; set; }
    }
}
