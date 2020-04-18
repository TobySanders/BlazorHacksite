using HackSite.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using System.Linq;
using HackSite.Server.Mappers;

namespace HackSite.Server.Controllers
{
    [Route("[Controller]")]
    public class UsersController : Controller
    {
        IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetUsersAsync();

            var result = new List<UserView>();

            foreach (var user in users)
            {
                result.Add(user.Map());
            }

            return new OkObjectResult(result);
        }
    }
}