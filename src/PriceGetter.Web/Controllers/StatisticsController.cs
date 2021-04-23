using Microsoft.AspNetCore.Mvc;
using PriceGetter.Statistics.Dtos;
using PriceGetter.Statistics.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    /// <summary>
    /// Product related statistics controller
    /// </summary>
    public class StatisticsController : AbstractController
    {
        private readonly IProductStatisticsService statisticsService;

        /// <summary>
        /// Object constructor with dependencies to be satisfied
        /// </summary>
        /// <param name="statisticsService">Product related things statistics service</param>
        public StatisticsController(IProductStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService ?? throw new System.ArgumentNullException(nameof(statisticsService));
        }

        /// <summary>
        /// Gets months statistics
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMonthsStatistics(Guid productId)
        {
            IEnumerable<MonthStatisticsDto> statistics = await this.statisticsService.PrepareMonthStatistics(productId);

            return Ok(statistics);
        }
    }
}
