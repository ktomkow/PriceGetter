using Autofac;
using PriceGetter.Core.Interfaces.Repositories;

namespace PriceGetter.PersistenceEntityFramework.IntegrationTests
{
    public abstract class TestClassWithServiceProvider
    {
        protected readonly IContainer serviceProvider;

        public TestClassWithServiceProvider()
        {
            ServicesResolverCreator servideResolver = new ServicesResolverCreator();
            this.serviceProvider = servideResolver.GetContainer();
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            return this.serviceProvider.Resolve<IUnitOfWork>();
        }
    }
}
