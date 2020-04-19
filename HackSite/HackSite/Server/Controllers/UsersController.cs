using HackSite.Server.Mappers;
using HackSite.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions;

namespace HackSite.Server.Controllers
{
    [ApiController]
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

            var result = new List<UserViewModel>();

            foreach (var user in users)
            {
                result.Add(user.Map());
            }

            return new OkObjectResult(result.ToArray());
        }
    }
}