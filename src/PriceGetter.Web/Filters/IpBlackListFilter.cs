using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PriceGetter.Infrastructure.IpBlackList;
using PriceGetter.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PriceGetter.Web.Filters
{
    public class IpBlackListFilter : ActionFilterAttribute
    {
        private readonly IIpBlackListService ipBlacklist;
        private readonly IPriceGetterLogger logger;

        public IpBlackListFilter(IIpBlackListService ipBlacklist, IPriceGetterLogger logger)
        {
            this.ipBlacklist = ipBlacklist;
            this.logger = logger;
        }

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
