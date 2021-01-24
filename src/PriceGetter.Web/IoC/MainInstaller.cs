using Autofac;
using Microsoft.AspNetCore.Hosting;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Main installer, calls other installers inside. 
    /// Does not call settings installer.
    /// </summary>
    public class MainInstaller : Module
    {
        private readonly IWebHostEnvironment env;

        /// <summary>
        /// Public constructor with dependencies
        /// </summary>
        /// <param name="env">Hosting enivonment</param>
        public MainInstaller(IWebHostEnvironment env)
        {
            this.env = env;
        }

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ContentProvidersInstaller());
            builder.RegisterModule(new DomainServicesInstaller());
            builder.RegisterModule(new PersistenceMongoInstaller());
            builder.RegisterModule(new PersistenceEntityFrameworkInstaller());
            builder.RegisterModule(new WebClientsInstaller(this.env));
            builder.RegisterModule(new ApplicationServicesInstaller());
            builder.RegisterModule(new WebAppComponentsInstaller());
            builder.RegisterModule(new InfrastructureInstaller());
        }
    }
}
