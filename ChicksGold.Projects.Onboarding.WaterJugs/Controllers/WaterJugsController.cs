using ChicksGold.Projects.Onboarding.WaterJugs.Helpers;
using ChicksGold.Projects.Onboarding.WaterJugs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChicksGold.Projects.Onboarding.WaterJugs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterJugsController : ControllerBase
    {
        
        private readonly ILogger<WaterJugsController> _logger;

        public WaterJugsController(ILogger<WaterJugsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Solve")]
        public ActionResult<List<State>> Solve(int jugX, int jugY, int target)
        {
            return MainLogic.Solve(jugX, jugY, target);            
        }
    }
}