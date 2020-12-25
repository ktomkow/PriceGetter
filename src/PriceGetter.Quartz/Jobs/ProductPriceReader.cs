using System;
using System.Threading.Tasks;
using PriceGetter.Core.Interfaces.PeriodActions;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Quartz.Configuration;
using Quartz;

namespace PriceGetter.Quartz.Jobs
{
    public class ProductPriceReader : SelfReschedulingAction, IJob
    {
        private readonly IServiceProvider serviceProvider;

        // private readonly IPriceGetterLogger logger;

        private readonly IScheduler scheduler;

        public override string TriggerKey => this.GetType().TriggerKey();

        public ProductPriceReader(
            IServiceProvider serviceProvider,
            // IPriceGetterLogger logger,
            IPeriodActionScheduler scheduler)
        {
            this.serviceProvider = serviceProvider;
            // this.logger = logger;
            this.scheduler = scheduler.Scheduler();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            if(await this.ShouldBeExecutedToday())
            {
                await this.Execute();
            }

            await this.Reschedule();
        }

        public override async Task Execute()
        {
            var logger = this.serviceProvider.GetService(typeof(IPriceGetterLogger)) as IPriceGetterLogger;
            logger.Debug($"Hello, it's me, {this.GetType().ToString()}!");

            IEx ex = this.serviceProvider.GetService(typeof(IEx)) as IEx;
            ex.Work();

            await Task.CompletedTask;
        }

        public override async Task<bool> ShouldBeExecutedToday()
        {
            return await Task.FromResult(true);
        }

        protected async override Task Reschedule()
        {
            ITrigger trigger = this.GetTrigger();

            var triggerKey = new TriggerKey(this.TriggerKey);
            await this.scheduler.RescheduleJob(triggerKey, trigger);
        }

        private ITrigger GetTrigger()
        {
            var nextExecutionTime = this.GetNextExecutionTime();
            // this.logger.Debug($"Next execution time: {nextExecutionTime}");

            ITrigger trigger = TriggerBuilder
                .Create()
                .WithIdentity(this.TriggerKey)
                .StartAt(nextExecutionTime)
                .Build();

            return trigger;
        }

        private DateTimeOffset GetNextExecutionTime()
        {
            return DateTime.Now.AddSeconds(5);
        }
    }
}