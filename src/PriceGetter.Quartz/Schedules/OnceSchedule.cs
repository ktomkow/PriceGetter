using PriceGetter.Quartz.Configuration;
using Quartz;
using System;

namespace PriceGetter.Quartz.Schedules
{
    public class OnceSchedule : JobSchedule
    {
        public OnceSchedule(Type jobType) : base(jobType)
        {
        }

        public override ITrigger CreateTrigger()
        {
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder
                .Create()
                .WithIdentity(this.triggerIdentity)
                .StartAt(DateTime.Now.AddSeconds(3))
                .Build();

            return trigger;
        }
    }
}
