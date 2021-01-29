using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PriceGetter.Core.Interfaces;
using PriceGetter.WebClients;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs web client.
    /// </summary>
    public class WebClientsInstaller : Module
    {
        private readonly IWebHostEnvironment env;

        /// <summary>
        /// Public constructor with dependencies
        /// </summary>
        /// <param name="env">Hosting enironment</param>
        public WebClientsInstaller(IWebHostEnvironment env)
        {
            this.env = env;
        }

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            if(this.env.IsProduction())
            {
                builder.RegisterType<HtmlGetter>().As<IHtmlContentGetter>().InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<FakeGetterUseFile>().As<IHtmlContentGetter>().InstancePerLifetimeScope();
            }
        }
    }
}
