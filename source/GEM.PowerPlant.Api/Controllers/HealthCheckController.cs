using Microsoft.AspNetCore.Mvc;

namespace GEM.PowerPlant.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GEM.PowerPlant.Api is running.");
        }
    }
}
