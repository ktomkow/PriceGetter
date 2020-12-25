using PriceGetter.Infrastructure.Logging;
using System;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Jobs
{
    public class HelloWorld : QuartzSelfRescheduleAction
    {
        private int counter = 0;

        public HelloWorld(
            IPriceGetterLogger logger,
            IPeriodActionScheduler scheduler) : base(scheduler, logger)
        {}

        public override async Task Execute()
        {
            this.logger.Information($"EXECUTION {counter++}");
            await Task.CompletedTask;
        }

        protected override async Task<bool> ShouldBeExecuted()
        {
            return await Task.FromResult(counter < 5);
        }

        protected override async Task<DateTime> NextExecutionTime()
        {
            var random = new Random();
            int number = random.Next(3) + 1;

            if (await this.ShouldBeExecuted())
            {
                return DateTime.Now.AddSeconds(number);
            }

            this.logger.Information("See you soon!\n\n\n");
            counter = 0;
            return DateTime.Now.AddSeconds(60);
        }
    }
}
