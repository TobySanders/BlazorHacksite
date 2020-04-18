using Microsoft.AspNetCore.Mvc;

namespace HackSite.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}