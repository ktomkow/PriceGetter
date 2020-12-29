using Autofac;
using PriceGetter.Core.Interfaces;
using PriceGetter.WebClients;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs web client.
    /// </summary>
    public class WebClientsInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterType<HtmlGetter>().As<IHtmlContentGetter>().InstancePerLifetimeScope();
            builder.RegisterType<FakeGetterUseFile>().As<IHtmlContentGetter>().InstancePerLifetimeScope();
        }
    }
}
