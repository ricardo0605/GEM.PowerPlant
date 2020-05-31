using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace GEM.PowerPlant.Api.Filters
{
    public class GlobalErrorFilter : ActionFilterAttribute
    {
        private readonly ILogger<GlobalErrorFilter> _logger;

        public GlobalErrorFilter(ILogger<GlobalErrorFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                _logger.LogWarning("Add detailed info to help documentation text to guide api consumer.");
            }

            if (filterContext.Exception != null)
            {
                _logger.LogError(filterContext.Exception.StackTrace);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}