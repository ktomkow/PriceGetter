using Autofac;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Persistence.Repositories;
using PriceGetter.PersistenceEntityFramework;
using PriceGetter.PersistenceEntityFramework.Repositories;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs persistence layer objects using entity framework in implementation.
    /// </summary>
    public class PersistenceEntityFrameworkInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<InMemoryProductRepository>().As<IProductsRepository>().SingleInstance();

            builder.RegisterType<PriceGetterDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
