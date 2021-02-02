using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PriceGetter.Infrastructure.Settings;

namespace PriceGetter.Web.Controllers
{
    [Route("/tech")]
    public class TechController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SqlSettings sqlSettings;
        private readonly LoggerSettings loggerSettings;

        public TechController(IWebHostEnvironment webHostEnvironment, SqlSettings sqlSettings, LoggerSettings loggerSettings)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.sqlSettings = sqlSettings;
            this.loggerSettings = loggerSettings;
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


            return Ok(configuration);
        }
    }
}
