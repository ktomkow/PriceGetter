using PriceGetter.Core.Interfaces.PeriodActions;
using PriceGetter.Infrastructure.Logging;
using Quartz;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Jobs
{
    public class HelloWorld : SelfReschedulingAction, IJob
    {
        private readonly IPriceGetterLogger logger;

        public HelloWorld(IPriceGetterLogger logger)
        {
            this.logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await this.Execute();

            await this.Reschedule();
        }

        public override async Task Execute()
        {
            this.logger.Information("Execution");
            await Task.CompletedTask;
        }

        public override async Task<bool> ShouldBeExecutedToday()
        {
            var random = new Random();

            return random.NextDouble() < 0.90;
        }

        protected override async Task Reschedule()
        {
            if(await this.ShouldBeExecutedToday())
            {
                var random = new Random();
                int number = random.Next(1) + 1;

                ITrigger trigger = TriggerBuilder
                .Create()
                .WithIdentity("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger")
                .StartAt(DateTime.Now.AddSeconds(number))
                .Build();

                var triggerKey = new TriggerKey("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger");
                await SchedulerContainer.Scheduler.RescheduleJob(triggerKey, trigger);

                this.logger.Information($"Rescheduling.. {number}");
            }
            else
            {
                this.logger.Information("Job is done");
                this.logger.Information("GOODNIGHT!");
            }
        }
    }
}
