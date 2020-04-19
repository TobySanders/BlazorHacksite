using HackSite.Server.Mappers;
using HackSite.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Abstractions;

namespace HackSite.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : Controller
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly ITeamRepository _teamRepository;

        public TeamsController(ILogger<TeamsController> logger, ITeamRepository teamRepository)
        {
            _logger = logger;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _teamRepository.GetTeamsAsync();

            var result = new List<TeamViewModel>();

            foreach (var team in teams)
            {
                result.Add(team.Map());
            }

            return new OkObjectResult(result.ToArray());

        }
    }
}