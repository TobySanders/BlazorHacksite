using System.ComponentModel.DataAnnotations;

namespace HackSite.Views
{
    public class CreateUserView
    {
        [Required (ErrorMessage = "Username is required")]
        [StringLength(24, ErrorMessage ="Username too long, maxium length is 24")]
        public string Username { get; set; }
    }
}
