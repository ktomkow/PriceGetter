using Autofac;
using PriceGetter.Statistics.Products.DefaultImplementation;
using PriceGetter.Statistics.Products.Interfaces;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs product statistics related things.
    /// </summary>
    public class StatisticsInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductStatisticsService>().As<IProductStatisticsService>().InstancePerLifetimeScope();
            builder.RegisterType<MonthStatisticsCreator>().As<IMonthStatisticsCreator>().InstancePerLifetimeScope();
        }
    }
}
