using PriceGetter.Statistics.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceGetter.Statistics.Products.Interfaces
{
    public interface IProductStatisticsService
    {
        Task<IEnumerable<MonthStatisticsDto>> PrepareMonthStatistics(Guid productId);
    }
}
