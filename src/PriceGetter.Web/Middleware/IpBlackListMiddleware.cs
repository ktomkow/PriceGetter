using Microsoft.AspNetCore.Http;
using PriceGetter.Infrastructure.IpBlackList;
using PriceGetter.Infrastructure.Logging;
using System.Net;
using System.Threading.Tasks;

namespace PriceGetter.Web.Middleware
{
    /// <summary>
    /// Middleware to block requests from banned ips
    /// </summary>
    public class IpBlackListMiddleware : MiddlewareBase
    {
        private readonly IIpBlackListService ipBlacklist;
        private readonly IPriceGetterLogger logger;

        /// <summary>
        /// Public constructor with dependencies
        /// </summary>
        /// <param name="next">Next middleware in chain</param>
        /// <param name="ipBlacklist">Ip black lsit service</param>
        /// <param name="logger">Logger implementation</param>
        public IpBlackListMiddleware(
            RequestDelegate next,
            IIpBlackListService ipBlacklist,
            IPriceGetterLogger logger) : base(next)
        {
            this.ipBlacklist = ipBlacklist;
            this.logger = logger;
        }

        /// <inheritdoc/>
        protected override async Task ExecuteBefore(HttpContext context)
        {
            IPAddress ip = context.Connection.RemoteIpAddress;

            this.logger.Information($"{this.GetType()} Incoming ip: {ip.ToString()}");

            if (this.ipBlacklist.IsAllowed(ip) == false)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await Task.CompletedTask;
                throw new System.Exception();
            }
        }
    }
}
