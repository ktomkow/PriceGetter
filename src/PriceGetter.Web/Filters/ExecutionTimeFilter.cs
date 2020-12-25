using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using PriceGetter.Infrastructure.Logging;

namespace PriceGetter.Web.Filters
{
    public class ExecutionTimeFilter : ActionFilterAttribute
    {
        private readonly Stopwatch stopwatch;

        private readonly IPriceGetterLogger logger;

        public ExecutionTimeFilter(IPriceGetterLogger logger)
        {
            this.stopwatch = new Stopwatch();
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.stopwatch.Start();

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            this.stopwatch.Stop();
            var elapsedTime = this.stopwatch.Elapsed;

            this.logger.Debug($"Route : {context.HttpContext.Request.Path.ToString()}, Elapsed time : {elapsedTime}");

            base.OnActionExecuted(context);
        }
    }
}