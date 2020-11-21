using Quartz;

namespace PriceGetter.Quartz
{
    public class PeriodActionScheduler : IPeriodActionScheduler
    {
        private IScheduler scheduler;

        public void Initialize(IScheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        public IScheduler Scheduler()
        {
            return scheduler;
        }
    }
}
