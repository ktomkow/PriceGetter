using Microsoft.AspNetCore.Mvc.Filters;
using PriceGetter.Infrastructure.IpBlackList;
using PriceGetter.Infrastructure.Logging;
using System.Net;

namespace PriceGetter.Web.Filters
{
    /// <summary>
    /// Filter that can block http request sent from banned ip.
    /// </summary>
    public class IpBlackListFilter : ActionFilterAttribute
    {
        private readonly IIpBlackListService ipBlacklist;
        private readonly IPriceGetterLogger logger;

        /// <summary>
        /// Public constructor of the object. Has some dependencies to be satisfied.
        /// </summary>
        /// <param name="ipBlacklist">Black list service.</param>
        /// <param name="logger">Logger.</param>
        public IpBlackListFilter(IIpBlackListService ipBlacklist, IPriceGetterLogger logger)
        {
            this.ipBlacklist = ipBlacklist;
            this.logger = logger;
        }

        /// <summary>
        /// Executes before the action is called. Checks if the http request was sent from banned ip.
        /// If so, it blocks it and produces a response.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IPAddress ip = context.HttpContext.Connection.RemoteIpAddress;

            this.logger.Information($"Incoming ip: {ip.ToString()}");

            if(this.ipBlacklist.IsAllowed(ip) == false)
            {
                context.Result = new IpBannedResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
