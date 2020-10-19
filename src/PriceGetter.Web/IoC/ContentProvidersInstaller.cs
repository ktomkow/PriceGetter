using Autofac;
using PriceGetter.ContentProvider.DataExtractors;
using PriceGetter.ContentProvider.DataExtractors.Xkom;
using PriceGetter.Core.Interfaces;

namespace PriceGetter.Web.IoC
{
    public class ContentProvidersInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PriceExtractorXkom>();
            builder.RegisterType<NameExtractorXkom>();
            builder.RegisterType<MainImageExtractorXkom>();
            builder.RegisterType<BasicCssExtractor>().As<ICssContentExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<CssPriceExtractor>().As<ICssPriceExtractor>().InstancePerLifetimeScope();
        }
    }
}
