using GEM.PowerPlant.Api.Dtos;
using GEM.PowerPlant.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mime;

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

        /// <summary>
        /// For calculating the unit-commitment.
        /// </summary>
        /// <param name="request">The load, fuels and powerplants at disposal.</param>
        /// <returns>The response should be a json as in example_response.json, specifying 
        /// for each powerplant how much power each powerplant should deliver. 
        /// The power produced by each powerplant has to be a multiple of 0.1 Mw and the sum of 
        /// the power produced by all the powerplants together should equal the load.</returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
