using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PriceGetter.Web.Filters
{
    /// <summary>
    /// Result that is produced when ip blocking filter blocks a request.
    /// </summary>
    public class IpBannedResult : IActionResult
    {
        /// <summary>
        /// Created result asynchronously.
        /// </summary>
        /// <param name="context">Context of http request.</param>
        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 403;
            await Task.CompletedTask;
        }
    }
}
