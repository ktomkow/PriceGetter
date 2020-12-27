
using Autofac;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Main installer, calls other installers inside. 
    /// Does not call settings installer.
    /// </summary>
    public class MainInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ContentProvidersInstaller());
            builder.RegisterModule(new DomainServicesInstaller());
            builder.RegisterModule(new PersistenceMongoInstaller());
            builder.RegisterModule(new PersistenceEntityFrameworkInstaller());
            builder.RegisterModule(new WebClientsInstaller());
            builder.RegisterModule(new ApplicationServicesInstaller());
            builder.RegisterModule(new WebAppComponentsInstaller());
            builder.RegisterModule(new QuartzInstaller());
            builder.RegisterModule(new InfrastructureInstaller());
        }
    }
}
