using Quartz;
using System;

namespace PriceGetter.Web.QuartzConfig
{
    public class CronSchedule : JobSchedule
    {
        public string CronExpression { get; }

        public CronSchedule(Type jobType, string cronExpression) : base(jobType)
        {
            if(string.IsNullOrWhiteSpace(cronExpression))
            {
                throw new ArgumentException("Invalid cron expression", nameof(cronExpression));
            }

            this.CronExpression = cronExpression;
        }

        public override ITrigger CreateTrigger()
        {
            string triggerIdentity = $"{this.JobType.FullName}.trigger";

            var trigger = TriggerBuilder
                .Create()
                .WithIdentity(triggerIdentity)
                .WithCronSchedule(CronExpression)
                .WithDescription(CronExpression)
                .Build();

            return trigger;
        }
    }
}
