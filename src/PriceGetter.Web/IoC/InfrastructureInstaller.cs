using Autofac;
using PriceGetter.Infrastructure.Cache;
using PriceGetter.Infrastructure.IpBlackList;
using PriceGetter.Infrastructure.Logging;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs infeastructure related objects like cache or logger
    /// </summary>
    public class InfrastructureInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Ex>().As<IEx>().InstancePerDependency();
            builder.RegisterType<CacheFacade>().As<ICacheFacade>().SingleInstance();
            builder.RegisterType<PriceGetterLogger>().As<IPriceGetterLogger>().SingleInstance();
            builder.RegisterType<IpBlackListService>().As<IIpBlackListService>().SingleInstance();
        }
    }
}