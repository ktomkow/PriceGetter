using Autofac;
using PriceGetter.ApplicationServices.Interfaces;
using PriceGetter.ApplicationServices.ServicesImplementation;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs application services.
    /// </summary>
    public class ApplicationServicesInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PreProductService>().As<IPreProductService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<PricesWatcher>().As<IPricesWatcher>();
        }
    }
}