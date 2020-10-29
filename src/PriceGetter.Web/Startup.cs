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
using PriceGetter.Infrastructure.Cache;
using PriceGetter.Infrastructure.IpBlackList;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.Quartz.Configuration;
using PriceGetter.Quartz.Jobs;
using PriceGetter.Quartz.Schedules;
using PriceGetter.Web.ExtensionMethods;
using PriceGetter.Web.Filters;
using PriceGetter.Web.IoC;
using PriceGetter.Web.Middleware;
using PriceGetter.Web.Tools.Unbaser;
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
            builder.RegisterModule(new MainInstaller());

            builder.RegisterType<UrlUnbaser>().As<IUrlUnbaser>().InstancePerLifetimeScope();
            builder.RegisterType<Unbaser>().As<IUnbaser>().InstancePerLifetimeScope();

            builder.RegisterType<CacheFacade>().As<ICacheFacade>().SingleInstance();
            builder.RegisterType<IpBlackListService>().As<IIpBlackListService>().SingleInstance();
            builder.RegisterType<PriceGetterLogger>().As<IPriceGetterLogger>().SingleInstance();
            builder.RegisterInstance(this.Configuration.GetSettings<SqlSettings>());
            builder.RegisterInstance(this.Configuration.GetSettings<MongoSettings>());
            builder.RegisterInstance(this.Configuration.GetSettings<LoggerSettings>());

            builder.RegisterType<IpBlackListFilter>().SingleInstance();

            builder.RegisterType<JobFactory>().As<IJobFactory>().SingleInstance();
            builder.RegisterType<StdSchedulerFactory>().As<ISchedulerFactory>().SingleInstance();

            builder.RegisterType<HelloWorld>().SingleInstance();
            builder.RegisterType<HelloWorldCroned>().SingleInstance();

            builder.RegisterInstance(JobSchedule.Create(
                typeof(HelloWorld)));

            builder.RegisterInstance(JobSchedule.Create(
                typeof(HelloWorldCroned),
                "0/5 * * * * ?"));
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
