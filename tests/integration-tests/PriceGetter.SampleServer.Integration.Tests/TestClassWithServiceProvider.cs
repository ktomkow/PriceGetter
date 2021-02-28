using Autofac;
using PriceGetter.Core.Interfaces.Repositories;

namespace PriceGetter.SampleServer.Integration.Tests
{
    public abstract class TestClassWithServiceProvider
    {
        protected readonly IContainer serviceProvider;
        protected readonly string samplesServerAddress;

        public TestClassWithServiceProvider()
        {
            ServicesResolverCreator servideResolver = new ServicesResolverCreator();

            this.serviceProvider = servideResolver.GetContainer();
            this.samplesServerAddress = "http://192.168.0.133:7001/";
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            return this.serviceProvider.Resolve<IUnitOfWork>();
        }
    }
}
