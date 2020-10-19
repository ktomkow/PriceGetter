using Autofac;
using PriceGetter.Core.Interfaces;
using PriceGetter.WebClients;

namespace PriceGetter.Web.IoC
{
    public class WebClientsInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HtmlGetter>().As<IHtmlContentGetter>().InstancePerLifetimeScope();
        }
    }
}
