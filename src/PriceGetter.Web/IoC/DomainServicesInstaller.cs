using Autofac;
using PriceGetter.Core.Interfaces.Factories;
using PriceGetter.DomainServices.Factories;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Install domain services.
    /// </summary>
    public class DomainServicesInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PreProductFactory>().As<IPreProductFactory>().InstancePerLifetimeScope();
            builder.RegisterType<ProductFactory>().As<IProductFactory>().InstancePerLifetimeScope();
        }
    }
}
