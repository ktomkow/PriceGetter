using Microsoft.AspNetCore.Mvc;
using PriceGetter.Quartz;
using PriceGetter.Quartz.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    public class QuartzController : AbstractController
    {
        private readonly IPeriodActionScheduler periodActionScheduler;

        public QuartzController(IPeriodActionScheduler periodActionScheduler)
        {
            this.periodActionScheduler = periodActionScheduler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string result = $"Static scheduler name: {SchedulerContainer.Scheduler.SchedulerName}";
            result += $"\nSingleton scheduler name: {this.periodActionScheduler.Scheduler().SchedulerName}";

            return Ok(result);
        }
    }
}
