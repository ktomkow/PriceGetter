using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NSubstitute;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.Web.IoC;

namespace PriceGetter.SampleServer.Integration.Tests
{
    internal class ServicesResolverCreator
    {
        private IContainer serviceProvider;

        internal ServicesResolverCreator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            IWebHostEnvironment webHostEnvironment = Substitute.For<IWebHostEnvironment>();
            webHostEnvironment.IsProduction().Returns(true);

            containerBuilder.RegisterModule(new MainInstaller(webHostEnvironment));

            SqlSettings sqlSettings = new SqlSettings()
            {
                ConnectionString = @"Server=192.168.0.133,6900;Database=PriceGetter;User Id=app;Password=pgApplication123!;"
            };

            containerBuilder.RegisterInstance(sqlSettings);

            this.serviceProvider = containerBuilder.Build();
        }

        internal IContainer GetContainer()
        {
            return this.serviceProvider;
        }
    }
}
