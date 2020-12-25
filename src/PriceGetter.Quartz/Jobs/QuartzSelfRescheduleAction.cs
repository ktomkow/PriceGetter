using System;
using System.Threading.Tasks;
using PriceGetter.Core.Interfaces.PeriodActions;
using PriceGetter.Quartz.Configuration;
using Quartz;

namespace PriceGetter.Quartz.Jobs
{
    public abstract class QuartzSelfRescheduleAction : SelfReschedulingAction, IJob
    {
        private string triggerKey => this.GetType().TriggerKey();

        private readonly IScheduler scheduler;

        protected QuartzSelfRescheduleAction(IPeriodActionScheduler scheduler)
        {
            this.scheduler = scheduler.Scheduler;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            if (await this.ShouldBeExecuted())
            {
                await this.Execute();
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