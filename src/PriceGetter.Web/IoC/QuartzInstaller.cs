using Autofac;
using PriceGetter.Quartz;
using PriceGetter.Quartz.Configuration;
using PriceGetter.Quartz.Jobs;
using PriceGetter.Quartz.Schedules;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs quartz-related objects - schedules, jobs, etc.
    /// </summary>
    public class QuartzInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JobFactory>().As<IJobFactory>().SingleInstance();
            builder.RegisterType<StdSchedulerFactory>().As<ISchedulerFactory>().SingleInstance();
            builder.RegisterType<HelloWorld>().SingleInstance();
            builder.RegisterType<ProductPriceReader>().SingleInstance();
            builder.RegisterType<HelloWorldCroned>().SingleInstance();
            builder.RegisterType<PeriodActionScheduler>().As<IPeriodActionScheduler>().SingleInstance();

            builder.RegisterInstance(JobSchedule.Create(
                typeof(ProductPriceReader)));

            //    builder.RegisterInstance(JobSchedule.Create(
            //        typeof(HelloWorldCroned),
            //        "0/5 * * * * ?"));
        }
    }
}