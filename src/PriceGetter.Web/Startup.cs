using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PriceGetter.ApplicationServices.SpecificDetailsProviders;
using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.ContentProvider.CssExtractors;
using PriceGetter.ContentProvider.ImagesUrlExtractors;
using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.ContentProvider.NameExtractors;
using PriceGetter.ContentProvider.PriceExtractors;
using PriceGetter.Core.Interfaces;
using PriceGetter.Web.Tools.Unbaser;
using PriceGetter.WebClients;

namespace PriceGetter.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<DetailsProvider>().As<IDetailsProvider>().InstancePerLifetimeScope();
            builder.RegisterType<SpecificDetailsProviderFactory>().As<ISpecificDetailsProviderFactory>().InstancePerLifetimeScope();
            builder.RegisterType<BasicCssExtractor>().As<ICssContentExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<CssPriceExtractor>().As<ICssPriceExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<HtmlGetter>().As<IHtmlContentGetter>().InstancePerLifetimeScope();
            builder.RegisterType<PriceExtractorXkom>();
            builder.RegisterType<NameExtractorXkom>();
            builder.RegisterType<MainImageExtractorXkom>();

            builder.RegisterType<UrlUnbaser>().As<IUrlUnbaser>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
