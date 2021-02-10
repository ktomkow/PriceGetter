using Microsoft.Extensions.Hosting;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Quartz;
using PriceGetter.Quartz.Schedules;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Configuration
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory schedulerFactory;
        private readonly IJobFactory jobFactory;
        private readonly IEnumerable<JobSchedule> jobSchedules;
        private readonly IPeriodActionScheduler periodActionScheduler;
        private readonly IPriceGetterLogger logger;

        public IScheduler Scheduler { get; set; }

        public QuartzHostedService(
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IEnumerable<JobSchedule> jobSchedules,
            IPeriodActionScheduler periodActionScheduler,
            IPriceGetterLogger logger)
        {
            this.schedulerFactory = schedulerFactory ?? throw new ArgumentNullException(nameof(schedulerFactory));
            this.jobFactory = jobFactory ?? throw new ArgumentNullException(nameof(jobFactory));
            this.jobSchedules = jobSchedules ?? throw new ArgumentNullException(nameof(jobSchedules));
            this.periodActionScheduler = periodActionScheduler ?? throw new ArgumentNullException(nameof(periodActionScheduler));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = jobFactory;

            foreach (var jobSchedule in jobSchedules)
            {
                this.logger.Fatal($"Starting job {jobSchedule.PayloadJob}");
                var job = jobSchedule.CreateJob();
                var trigger = jobSchedule.CreateTrigger();

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
            SchedulerContainer.Scheduler = Scheduler;
            this.periodActionScheduler.Initialize(Scheduler);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }
    }
}
