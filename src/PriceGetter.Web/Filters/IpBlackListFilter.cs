using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PriceGetter.Infrastructure.IpBlackList;
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

        public IpBlackListFilter(IIpBlackListService ipBlacklist)
        {
            this.ipBlacklist = ipBlacklist;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IPAddress ip = context.HttpContext.Connection.RemoteIpAddress;

            if(this.ipBlacklist.IsAllowed(ip) == false)
            {
                context.Result = new IpBannedResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
