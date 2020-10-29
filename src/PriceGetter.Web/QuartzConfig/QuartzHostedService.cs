using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Hosting;
using PriceGetter.Quartz;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PriceGetter.Web.QuartzConfig
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory schedulerFactory;
        private readonly IJobFactory jobFactory;
        private readonly IEnumerable<JobSchedule> jobSchedules;

        public IScheduler Scheduler { get; set; }

        public QuartzHostedService(
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IEnumerable<JobSchedule> jobSchedules)
        {
            this.schedulerFactory = schedulerFactory ?? throw new ArgumentNullException(nameof(schedulerFactory));
            this.jobFactory = jobFactory ?? throw new ArgumentNullException(nameof(jobFactory));
            this.jobSchedules = jobSchedules ?? throw new ArgumentNullException(nameof(jobSchedules));
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = jobFactory;

            foreach (var jobSchedule in jobSchedules)
            {
                var job = jobSchedule.CreateJob();
                var trigger = jobSchedule.CreateTrigger();

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
            SchedulerContainer.Scheduler = Scheduler;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }
    }
}
