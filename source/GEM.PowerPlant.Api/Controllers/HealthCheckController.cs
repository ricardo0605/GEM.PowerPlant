using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GEM.PowerPlant.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GEM.PowerPlant.Api is running.");
        }
    }
}
