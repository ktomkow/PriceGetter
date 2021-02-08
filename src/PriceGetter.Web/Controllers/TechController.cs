using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Infrastructure.Settings;

namespace PriceGetter.Web.Controllers
{
    [Route("/tech")]
    public class TechController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SqlSettings sqlSettings;
        private readonly LoggerSettings loggerSettings;
        private readonly IPriceGetterLogger logger;

        public TechController(IWebHostEnvironment webHostEnvironment, SqlSettings sqlSettings, LoggerSettings loggerSettings, IPriceGetterLogger logger)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.sqlSettings = sqlSettings;
            this.loggerSettings = loggerSettings;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var configuration = new
            {
                ApplicationName = this.webHostEnvironment.ApplicationName,
                HostingEnvironment = this.webHostEnvironment.EnvironmentName,
                SqlConnectionString = this.sqlSettings.ConnectionString,
                LoggerPath = this.loggerSettings.LogFilepath
            };

            this.logger.Information("info");
            this.logger.Debug("debug");
            this.logger.Error("error");
            this.logger.Fatal("critical");


            return Ok(configuration);
        }
    }
}
