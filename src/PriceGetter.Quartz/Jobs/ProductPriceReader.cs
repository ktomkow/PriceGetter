using System;
using System.Threading.Tasks;
using PriceGetter.Infrastructure.Logging;
using Quartz;

namespace PriceGetter.Quartz.Jobs
{
    public class ProductPriceReader : QuartzSelfRescheduleAction
    {
        private readonly IServiceProvider serviceProvider;

        public ProductPriceReader(
            IServiceProvider serviceProvider,
            IPeriodActionScheduler scheduler,
            IPriceGetterLogger logger) : base(scheduler, logger)
        {
            this.serviceProvider = serviceProvider;
        }

        public override async Task Execute()
        {
            var logger = this.serviceProvider.GetService(typeof(IPriceGetterLogger)) as IPriceGetterLogger;
            logger.Debug($"Hello, it's me, {this.GetType().ToString()}!");

            IEx ex = this.serviceProvider.GetService(typeof(IEx)) as IEx;
            ex.Work();

            await Task.CompletedTask;
        }

        protected override async Task<DateTime> NextExecutionTime()
        {
            return await Task.FromResult(DateTime.Now.AddSeconds(5));
        }
    }
}