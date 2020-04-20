using HackSite.Mappers;
using HackSite.ViewModels;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Abstractions;

namespace HackSite.Controllers
{
    public class TeamsController
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILogger<TeamsController> _logger;

        public TeamsController(ITeamRepository teamRepository, ILogger<TeamsController> logger)
        {
            _teamRepository = teamRepository;
            _logger = logger;
        }

        public async Task<GetTeamsView> GetTeamsAsync()
        {
            var result = await _teamRepository.GetTeamsAsync();

            return new GetTeamsView
            {
                Teams = result.Select(team => team.Map())
            };
        }
    }
}
