using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PriceGetter.Web.Middleware
{
    /// <summary>
    /// Base class for middleware
    /// </summary>
    public abstract class MiddlewareBase
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Public base class constructor
        /// </summary>
        /// <param name="next">Next function to be executed in chain</param>
        public MiddlewareBase(RequestDelegate next)
        {
            this.next = next ?? throw new System.ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Action triggered by framework during handling http request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            await this.ExecuteBefore(context);

            if (this.next != null)
            {
                await this.next.Invoke(context);
            }

            await this.ExecuteAfter(context);
        }

        /// <summary>
        /// Action to be executed before hits controller
        /// </summary>
        /// <param name="context">Context</param>
        protected virtual async Task ExecuteBefore(HttpContext context) 
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Action to be executed after hits controller
        /// </summary>
        /// <param name="context">Context</param>
        protected virtual async Task ExecuteAfter(HttpContext context) 
        {
            await Task.CompletedTask;
        }
    }
}