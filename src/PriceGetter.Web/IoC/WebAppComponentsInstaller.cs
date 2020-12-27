using Autofac;
using PriceGetter.Web.Filters;
using PriceGetter.Web.Tools.Unbaser;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs tools and components defined in web app such as middleware, filters, tools.
    /// </summary>
    public class WebAppComponentsInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IpBlackListFilter>().SingleInstance();
            builder.RegisterType<ExecutionTimeFilter>().InstancePerLifetimeScope();
            builder.RegisterType<UrlUnbaser>().As<IUrlUnbaser>().InstancePerLifetimeScope();
            builder.RegisterType<Unbaser>().As<IUnbaser>().InstancePerLifetimeScope();
        }
    }
}