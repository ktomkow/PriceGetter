using PriceGetter.Infrastructure.Logging;
using Quartz;
using System;
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

            var triggerKey = new TriggerKey("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger");
            await SchedulerContainer.Scheduler.RescheduleJob(triggerKey, Dupa());
        }

        private ITrigger Dupa()
        {
            var random = new Random();
            int number = random.Next(5) + 1;
            this.logger.Information($"Random number: {number}");

            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder
                .Create()
                .WithIdentity("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger")
                .StartAt(DateTime.Now.AddSeconds(number))
                .Build();

            return trigger;
        }
    }
}
