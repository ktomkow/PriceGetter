using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using PriceGetter.Infrastructure.Logging;

namespace PriceGetter.Web.Filters
{
    /// <summary>
    /// Filter that measures and writo to a console time of action execution.
    /// </summary>
    public class ExecutionTimeFilter : ActionFilterAttribute
    {
        private readonly Stopwatch stopwatch;

        private readonly IPriceGetterLogger logger;

        /// <summary>
        /// Pubic constructor. It has some dependencies to be satisfied.
        /// </summary>
        /// <param name="logger">Logger that should be injected.</param>
        public ExecutionTimeFilter(IPriceGetterLogger logger)
        {
            this.stopwatch = new Stopwatch();
            this.logger = logger;
        }

        /// <summary>
        /// Starts the stopwatch.
        /// </summary>
        /// <param name="context">Context of action execution</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.stopwatch.Start();

            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Stops the stopwatch and prints the time of execution.
        /// </summary>
        /// <param name="context">Context of action execution</param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            this.stopwatch.Stop();
            var elapsedTime = this.stopwatch.Elapsed;

            this.logger.Debug($"Route : {context.HttpContext.Request.Path.ToString()}, Elapsed time : {elapsedTime}");

            base.OnActionExecuted(context);
        }
    }
}