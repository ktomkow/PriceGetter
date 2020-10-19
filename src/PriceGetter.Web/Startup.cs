using System;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PriceGetter.ApplicationServices.PriceProviders;
using PriceGetter.ApplicationServices.ProductServices;
using PriceGetter.ApplicationServices.SpecificDetailsProviders;
using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.ContentProvider.DataExtractors;
using PriceGetter.ContentProvider.DataExtractors.Xkom;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Infrastructure.Cache;
using PriceGetter.Infrastructure.IpBlackList;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.Persistence.Repositories;
using PriceGetter.PersistenceEntityFramework;
using PriceGetter.PersistenceMongo.Tools;
using PriceGetter.Quartz.Jobs;
using PriceGetter.Web.ExtensionMethods;
using PriceGetter.Web.Fakes;
using PriceGetter.Web.Filters;
using PriceGetter.Web.Middleware;
using PriceGetter.Web.QuartzConfig;
using PriceGetter.Web.Tools.Unbaser;
using PriceGetter.WebClients;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

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
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddHostedService<QuartzHostedService>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<DetailsProviderFake>().As<IDetailsProvider>().InstancePerLifetimeScope();
            
            builder.RegisterType<SpecificDetailsProviderFactory>().As<ISpecificDetailsProviderFactory>().InstancePerLifetimeScope();
            builder.RegisterType<BasicCssExtractor>().As<ICssContentExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<CssPriceExtractor>().As<ICssPriceExtractor>().InstancePerLifetimeScope();
            builder.RegisterType<HtmlGetter>().As<IHtmlContentGetter>().InstancePerLifetimeScope();
            builder.RegisterType<PriceExtractorXkom>();
            builder.RegisterType<NameExtractorXkom>();
            builder.RegisterType<MainImageExtractorXkom>();

            builder.RegisterType<UrlUnbaser>().As<IUrlUnbaser>().InstancePerLifetimeScope();
            builder.RegisterType<Unbaser>().As<IUnbaser>().InstancePerLifetimeScope();

            builder.RegisterType<CacheFacade>().As<ICacheFacade>().SingleInstance();
            builder.RegisterType<IpBlackListService>().As<IIpBlackListService>().SingleInstance();
            builder.RegisterType<PriceGetterLogger>().As<IPriceGetterLogger>().SingleInstance();
            builder.RegisterInstance(this.Configuration.GetSettings<SqlSettings>());
            builder.RegisterInstance(this.Configuration.GetSettings<MongoSettings>());
            builder.RegisterInstance(this.Configuration.GetSettings<LoggerSettings>());

            builder.RegisterType<IpBlackListFilter>().SingleInstance();

            //builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<InMemoryProductRepository>().As<IProductsRepository>().SingleInstance();

            builder.RegisterType<CollectionProvider>().As<ICollectionProvider>();
            builder.RegisterType<DbCleaner>().As<IDbCleaner>();

            builder.RegisterType<PriceGetterDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();


            builder.RegisterType<JobFactory>().As<IJobFactory>().SingleInstance();
            builder.RegisterType<StdSchedulerFactory>().As<ISchedulerFactory>().SingleInstance();

            builder.RegisterType<HelloWorld>().SingleInstance();

            builder.RegisterInstance(new JobSchedule(
                jobType: typeof(HelloWorld),
                cronExpression: "0/5 * * * * ?"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseMiddleware<IpBlackListMiddleware>();

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

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
