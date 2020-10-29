using PriceGetter.Infrastructure.Logging;
using Quartz;
using System.Threading.Tasks;

namespace PriceGetter.Quartz.Jobs
{
    public class HelloWorldCroned : IJob
    {
        private readonly IPriceGetterLogger logger;

        public HelloWorldCroned(IPriceGetterLogger logger)
        {
            this.logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Delay(100);
            this.logger.Information("Hello, World Croned!");
        }
    }
}
