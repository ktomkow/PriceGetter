using Microsoft.AspNetCore.Http;
using PriceGetter.Infrastructure.Logging;
using System;
using System.Threading.Tasks;

namespace PriceGetter.Web.Middleware
{
    /// <summary>
    /// Middleware to log incaught exceptions
    /// </summary>
    public class UncaughtExceptionMiddleware
    {
        private RequestDelegate next;
        private readonly IPriceGetterLogger logger;

        public UncaughtExceptionMiddleware(RequestDelegate next, IPriceGetterLogger logger)
        {
            this.next = next ?? throw new System.ArgumentNullException(nameof(next));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.logger.Error(e.Message + e.StackTrace);
                throw;
            }
        }
    }
}
