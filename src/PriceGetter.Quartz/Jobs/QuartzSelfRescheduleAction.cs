using System;
using System.Threading.Tasks;
using PriceGetter.Core.Interfaces.PeriodActions;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Quartz.Configuration;
using Quartz;

namespace PriceGetter.Quartz.Jobs
{
    public abstract class QuartzSelfRescheduleAction : SelfReschedulingAction, IJob
    {
        private string triggerKey => this.GetType().TriggerKey();

        private readonly IScheduler scheduler;

        protected readonly IPriceGetterLogger logger;

        protected QuartzSelfRescheduleAction(
            IPeriodActionScheduler scheduler,
            IPriceGetterLogger logger)
        {
            this.scheduler = scheduler.Scheduler;
            this.logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                if (await this.ShouldBeExecuted())
                {
                    await this.Execute();
                }
            }
            catch(Exception e)
            {
                this.logger.Error($"{e.Message} \n\n {e.StackTrace}");
            }

            await this.Reschedule();
        }

        protected override async Task Reschedule()
        {
            ITrigger trigger = await this.GetTrigger();

            var triggerKey = new TriggerKey(this.triggerKey);
            await this.scheduler.RescheduleJob(triggerKey, trigger);
        }

        private async Task<ITrigger> GetTrigger()
        {
            ITrigger trigger = TriggerBuilder
                .Create()
                .WithIdentity(this.triggerKey)
                .StartAt(await this.NextExecutionTime())
                .Build();

            return trigger;
        }

        public override abstract Task Execute();

        protected virtual async Task<bool> ShouldBeExecuted() => await Task.FromResult(true);

        protected virtual async Task<DateTime> NextExecutionTime()
        {
            return await Task.FromResult(DateTime.UtcNow.Date.AddDays(1).AddHours(7));
        }
    }
}