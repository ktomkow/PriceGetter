using Autofac;
using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.ApplicationServices.ServicesImplementation;

namespace PriceGetter.Web.IoC
{
    public class ApplicationServicesInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PreProductService>().As<IPreProductService>();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
        }
    }
}
