namespace HackSite.Data
{
    public class TeamView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProjectView project { get; set; }
    }
}
