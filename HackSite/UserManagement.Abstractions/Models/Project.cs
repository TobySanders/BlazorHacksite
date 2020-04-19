namespace UserManagement.Abstractions.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GithubUrl { get; set; }
    }
}
