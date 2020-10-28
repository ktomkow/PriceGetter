using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Quartz
{
    public static class SchedulerContainer
    {
        private static IScheduler scheduler;

        public static IScheduler Scheduler 
        { 
            get => scheduler; 
            set 
            {
                if(scheduler == null)
                {
                    scheduler = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            } 
        }
    }
}
