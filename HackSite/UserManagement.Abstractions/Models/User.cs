using System.Collections.Generic;

namespace UserManagement.Abstractions.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<int> TeamIds { get; set; }
    }
}
