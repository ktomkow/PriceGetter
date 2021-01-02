using Autofac;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.Web.IoC;

namespace PriceGetter.PersistenceEntityFramework.IntegrationTests
{
    internal class ServicesResolverCreator
    {
        private IContainer serviceProvider;

        internal ServicesResolverCreator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new MainInstaller());

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
