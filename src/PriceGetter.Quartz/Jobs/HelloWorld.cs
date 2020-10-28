using PriceGetter.Infrastructure.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Jobs
{
    public class HelloWorld : IJob
    {
        private readonly IPriceGetterLogger logger;

        //private readonly IScheduler scheduler;

        public HelloWorld(IPriceGetterLogger logger)
        {
            this.logger = logger;
            //this.scheduler = scheduler ?? throw new ArgumentNullException(nameof(scheduler));
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(100);
            this.logger.Information("Hello, World!");

            //await this.scheduler.RescheduleJob()
            var triggerKey = new TriggerKey("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger");
            SchedulerContainer.Scheduler.RescheduleJob(triggerKey, Dupa());
        }

        private ITrigger Dupa()
        {
            var random = new Random();
            int number = random.Next(5);
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
