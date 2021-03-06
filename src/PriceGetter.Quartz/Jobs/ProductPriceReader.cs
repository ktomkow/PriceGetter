using System;
using System.Threading.Tasks;
using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Infrastructure.Logging;

namespace PriceGetter.Quartz.Jobs
{
    public class ProductPriceReader : QuartzSelfRescheduleAction
    {
        private readonly IServiceProvider serviceProvider;
        private readonly Random random;

        public ProductPriceReader(
            IServiceProvider serviceProvider,
            IPeriodActionScheduler scheduler,
            IPriceGetterLogger logger) : base(scheduler, logger)
        {
            this.serviceProvider = serviceProvider;
            this.random = new Random();
        }

        public override async Task Execute()
        {
            var watcher = this.GetWatcher();

            await watcher.CheckPriceOfRandomProduct();
        }

        protected override async Task<DateTime> NextExecutionTime()
        {
            if (await this.ShouldBeExecuted())
            {
                return DateTime.Now.AddSeconds(this.GetRandomSeconds());
            }

            return DateTimeMethods.TommorowAt(6);
        }

        protected override async Task<bool> ShouldBeExecuted()
        {
            var watcher = this.GetWatcher();
            return await watcher.AnyWorkLeft();
        }

        private int GetRandomSeconds()
        {
            int result = this.random.Next(10, 120);
            return result;
        }

        private IPricesWatcher GetWatcher()
        {
            IPricesWatcher pricesWatcher = this.serviceProvider.GetService(typeof(IPricesWatcher)) as IPricesWatcher;
            if (pricesWatcher is null)
            {
                this.logger.Error("Cannot resolve IPricesWatcher!");
                throw new Exception();
            }

            return pricesWatcher;
        }
    }
}