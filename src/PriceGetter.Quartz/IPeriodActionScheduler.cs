using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Quartz
{
    public interface IPeriodActionScheduler
    {
        IScheduler Scheduler();

        void Initialize(IScheduler scheduler);
    }
}
