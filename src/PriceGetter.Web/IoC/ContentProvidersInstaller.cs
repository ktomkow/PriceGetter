using Autofac;
using PriceGetter.ApplicationServices.PriceProviders.Sellers;
using PriceGetter.ContentProvider.DataExtractors;
using PriceGetter.ContentProvider.DataExtractors.Xkom;
using PriceGetter.ContentProvider.DataProviders.Xkom;
using PriceGetter.ContentProvider.DataProviders.XKom;
using PriceGetter.ContentProvider.Factories;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors.Xkom;
using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.DataProviders.Xkom;
using PriceGetter.Core.Interfaces.Factories.DataProviders;
using System.Reflection;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs content providers.
    /// </summary>
    public class ContentProvidersInstaller : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(BasicCssExtractor)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterType<BasicCssExtractor>().As<ICssContentExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<CssPriceExtractor>().As<ICssPriceExtractor>().InstancePerLifetimeScope();

            builder.RegisterType<DataProviderFactory>().As<IDataProviderFactory>().InstancePerLifetimeScope();

            builder.RegisterType<PriceExtractorXkom>().As<IXkomPriceExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<NameExtractorXkom>().As<IXkomNameExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<MainImageExtractorXkom>().As<IXkomImageUrlExtractor>().InstancePerLifetimeScope();

            builder.RegisterType<XKomImageProvider>().As<IXkomImageUrlProvider>().InstancePerLifetimeScope();
            builder.RegisterType<XKomPriceProvider>().As<IXkomPriceProvider>().InstancePerLifetimeScope();
            builder.RegisterType<XKomNameProvider>().As<IXkomNameProvider>().InstancePerLifetimeScope();

            builder.RegisterType<XKomDataProvider>().As<IDataProvider>().InstancePerLifetimeScope();
        }
    }
}
