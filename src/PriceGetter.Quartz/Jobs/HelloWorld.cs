using PriceGetter.Infrastructure.Logging;
using Quartz;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Jobs
{
    public class HelloWorld : IJob
    {
        private readonly IPriceGetterLogger logger;

        public HelloWorld(IPriceGetterLogger logger)
        {
            this.logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(100);
            this.logger.Information("Hello, World!");

            await this.Reschedule();
        }

        private async Task Reschedule()
        {
            var random = new Random();
            int number = random.Next(5) + 1;
            this.logger.Information($"Random number: {number}");

            ITrigger trigger = TriggerBuilder
                .Create()
                .WithIdentity("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger")
                .StartAt(DateTime.Now.AddSeconds(number))
                .Build();

            var triggerKey = new TriggerKey("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger");
            await SchedulerContainer.Scheduler.RescheduleJob(triggerKey, trigger);
        }
    }
}
