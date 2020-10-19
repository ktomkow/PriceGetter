
using Autofac;

namespace PriceGetter.Web.IoC
{
    public class MainInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ContentProvidersInstaller());
            builder.RegisterModule(new DomainServicesInstaller());
        }
    }
}
