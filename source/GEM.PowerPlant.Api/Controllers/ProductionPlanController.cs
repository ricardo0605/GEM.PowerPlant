using GEM.PowerPlant.Api.Dtos;
using GEM.PowerPlant.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GEM.PowerPlant.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IMultitudeService service;
        private readonly ILogger<ProductionPlanController> logger;

        public ProductionPlanController(IMultitudeService service,
                                        ILogger<ProductionPlanController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RequestPayload request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = service.SolveUnitCommitment(request);

            return Ok(result);
        }
    }
}
