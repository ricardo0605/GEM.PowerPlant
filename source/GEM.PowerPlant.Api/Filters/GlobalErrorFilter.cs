using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GEM.PowerPlant.Api.Filters
{
    public class GlobalErrorFilter : IAsyncActionFilter
    {
        private readonly ILogger<filterTest> logger;

        public GlobalErrorFilter(ILogger<filterTest> logger)
        {
            this.logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                                 ActionExecutionDelegate next)
        {
            // logic before action

            await next(); // the actual action

            // logic after the action
        }
    }
}
