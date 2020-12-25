using PriceGetter.Core.Interfaces.PeriodActions;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Quartz.Configuration;
using Quartz;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Jobs
{
    public class HelloWorld : SelfReschedulingAction, IJob
    {
        private readonly IPriceGetterLogger logger;
        private readonly IScheduler scheduler;
        private int counter = 10;

        public HelloWorld(IPriceGetterLogger logger, IPeriodActionScheduler scheduler)
        {
            this.logger = logger;
            this.scheduler = scheduler.Scheduler();
        }

        public override string TriggerKey => this.GetType().TriggerKey();

        public async Task Execute(IJobExecutionContext context)
        {
            if(await this.ShouldBeExecutedToday())
            {
                await this.Execute();
            }

            await this.Reschedule();
        }

        public override async Task Execute()
        {
            this.logger.Information($"EXECUTION {counter++}");
            await Task.CompletedTask;
        }

        public override async Task<bool> ShouldBeExecutedToday()
        {
            if(counter < 5)
            {
                return await Task.FromResult(true);
            }

            var random = new Random();
            if(random.NextDouble() > 0.75)
            {
                counter = 0;
            }

            return await Task.FromResult(false);
        }

        protected override async Task Reschedule()
        {             
            ITrigger trigger = await this.GetTrigger();

            var triggerKey = new TriggerKey(this.TriggerKey);
            await this.scheduler.RescheduleJob(triggerKey, trigger);   
        }

        private async Task<ITrigger> GetTrigger()
        {
            ITrigger trigger = TriggerBuilder
                .Create()
                .WithIdentity(this.TriggerKey)
                .StartAt(await this.NextExecutionTime())
                .Build();

            return trigger;
        }

        private async Task<DateTime> NextExecutionTime()
        {
            var random = new Random();
            int number = random.Next(3) + 1;

            if (await this.ShouldBeExecutedToday())
            {
                return DateTime.Now.AddSeconds(number);
            }

            this.logger.Information("See you soon!\n\n\n");
            return DateTime.Now.AddSeconds(60);
        }
    }
}
