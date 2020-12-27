using Autofac;
using Microsoft.Extensions.Configuration;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.Web.ExtensionMethods;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installing 'Settings' instances using IConfigurationRoot.
    /// </summary>
    public class SettingsInstaller: Module
    {
        private readonly IConfigurationRoot configuration;

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="configuration">Configuration with settings</param>
        public SettingsInstaller(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(this.configuration.GetSettings<SqlSettings>());
            builder.RegisterInstance(this.configuration.GetSettings<MongoSettings>());
            builder.RegisterInstance(this.configuration.GetSettings<LoggerSettings>());
        }
    }
}