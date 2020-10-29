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
                .WithIdentity("DEFAULT.PriceGetter.Quartz.Jobs.HelloWorld.trigger")
                .StartAt(DateTime.Now.AddSeconds(2))
                .Build();

            return trigger;
        }
    }
}
