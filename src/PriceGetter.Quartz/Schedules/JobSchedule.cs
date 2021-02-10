using PriceGetter.Quartz.Configuration;
using Quartz;
using System;

namespace PriceGetter.Quartz.Schedules
{
    public abstract class JobSchedule
    {
        protected Type JobType { get; }

        protected string triggerIdentity => this.JobType.TriggerKey();

        public string PayloadJob => this.JobType.Name;

        protected JobSchedule(Type jobType)
        {
            this.JobType = jobType ?? throw new ArgumentNullException(nameof(jobType));
        }

        public static JobSchedule Create(Type type)
        {
            JobSchedule jobSchedule = new OnceSchedule(type);

            return jobSchedule;
        }

        public static JobSchedule Create(Type type, string cron)
        {
            return new CronSchedule(type, cron);
        }

        public abstract ITrigger CreateTrigger();

        public IJobDetail CreateJob()
        {
            var jobDetail = JobBuilder
                .Create(this.JobType)
                .WithIdentity(this.JobType.FullName)
                .WithDescription(this.JobType.Name)
                .Build();

            return jobDetail;
        }
    }
}
