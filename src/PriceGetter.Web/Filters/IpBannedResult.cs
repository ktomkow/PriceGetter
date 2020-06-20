using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Filters
{
    public class IpBannedResult : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 403;
            await Task.CompletedTask;
        }
    }
}
