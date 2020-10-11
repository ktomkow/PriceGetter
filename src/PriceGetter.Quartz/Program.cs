using PriceGetter.Quartz.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Quartz
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Let's do it");

            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
            .Build();

            await scheduler.ScheduleJob(job, trigger);
            Console.ReadLine();
            Console.WriteLine("I'm done");
        }
    }
}
