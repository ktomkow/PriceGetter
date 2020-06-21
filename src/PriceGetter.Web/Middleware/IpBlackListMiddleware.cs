using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PriceGetter.Infrastructure.IpBlackList;
using PriceGetter.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PriceGetter.Web.Middleware
{
    public class IpBlackListMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IIpBlackListService ipBlacklist;
        private readonly IPriceGetterLogger logger;

        public IpBlackListMiddleware(RequestDelegate next, IIpBlackListService ipBlacklist, IPriceGetterLogger logger)
        {
            this.next = next;
            this.ipBlacklist = ipBlacklist;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            IPAddress ip = context.Connection.RemoteIpAddress;

            this.logger.Information($"{this.GetType()} Incoming ip: {ip.ToString()}");

            if (this.ipBlacklist.IsAllowed(ip) == false)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }

            if(this.next != null)
            {
                await this.next.Invoke(context);
            }
        }
    }
}
