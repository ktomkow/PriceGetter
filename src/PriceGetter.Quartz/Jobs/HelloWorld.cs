using PriceGetter.Infrastructure.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Jobs
{
    public class HelloWorld : IJob
    {
        private readonly IPriceGetterLogger logger;

        public HelloWorld(IPriceGetterLogger logger)
        {
            this.logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(100);
            this.logger.Information("Hello, World!");
        }
    }
}
