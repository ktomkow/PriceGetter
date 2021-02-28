using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NSubstitute;
using PriceGetter.Core.Interfaces;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.Web.IoC;
using PriceGetter.WebClients;

namespace PriceGetter.SampleServer.Integration.Tests
{
    internal class ServicesResolverCreator
    {
        private IContainer serviceProvider;

        internal ServicesResolverCreator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new ContentProvidersInstaller());
            containerBuilder.RegisterModule(new DomainServicesInstaller());
            containerBuilder.RegisterModule(new ApplicationServicesInstaller());
            containerBuilder.RegisterModule(new InfrastructureInstaller());

            containerBuilder.RegisterType<HtmlGetter>().As<IHtmlContentGetter>().InstancePerLifetimeScope();

            IPriceGetterLogger mockLogger = Substitute.For<IPriceGetterLogger>();
            containerBuilder.RegisterInstance(mockLogger);

            this.serviceProvider = containerBuilder.Build();
        }

        internal IContainer GetContainer()
        {
            return this.serviceProvider;
        }
    }
}
