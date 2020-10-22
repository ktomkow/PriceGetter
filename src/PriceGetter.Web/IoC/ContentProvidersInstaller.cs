using Autofac;
using PriceGetter.ContentProvider.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors;

namespace PriceGetter.Web.IoC
{
    public class ContentProvidersInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<BasicCssExtractor>().As<ICssContentExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<CssPriceExtractor>().As<ICssPriceExtractor>().InstancePerLifetimeScope();
        }
    }
}
