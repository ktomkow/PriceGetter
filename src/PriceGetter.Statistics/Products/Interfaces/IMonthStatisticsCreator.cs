using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System.Collections.Generic;

namespace PriceGetter.Statistics.Products.Interfaces
{
    public interface IMonthStatisticsCreator
    {
        IEnumerable<MonthStatistics> Create(Product product);
    }
}
