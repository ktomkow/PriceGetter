using Autofac;
using PriceGetter.Core.Interfaces.Factories;
using PriceGetter.DomainServices.Factories;

namespace PriceGetter.Web.IoC
{
    public class DomainServicesInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PreProductFactory>().As<IPreProductFactory>().InstancePerLifetimeScope();
            builder.RegisterType<ProductFactory>().As<IProductFactory>().InstancePerLifetimeScope();
        }
    }
}
