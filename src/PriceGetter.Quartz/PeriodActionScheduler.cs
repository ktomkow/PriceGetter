using System;
using Quartz;

namespace PriceGetter.Quartz
{
    public class PeriodActionScheduler : IPeriodActionScheduler
    {
        private IScheduler scheduler;

        IScheduler IPeriodActionScheduler.Scheduler => this.scheduler;

        public void Initialize(IScheduler scheduler)
        {
            if(this.scheduler is null)
            {
                this.scheduler = scheduler;
                return;
            }

            throw new InvalidOperationException("Scheduler is already initialized!");
        }
    }
}
