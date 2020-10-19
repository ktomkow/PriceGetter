using Autofac;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Persistence.Repositories;
using PriceGetter.PersistenceEntityFramework;

namespace PriceGetter.Web.IoC
{
    public class PersistenceEntityFrameworkInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<InMemoryProductRepository>().As<IProductsRepository>().SingleInstance();

            builder.RegisterType<PriceGetterDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
