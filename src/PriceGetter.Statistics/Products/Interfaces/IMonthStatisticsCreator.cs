using PriceGetter.Core.Models.Entities;
using PriceGetter.Statistics.Domain;
using System.Collections.Generic;

namespace PriceGetter.Statistics.Products.Interfaces
{
    public interface IMonthStatisticsCreator
    {
        IEnumerable<MonthStatistics> Create(Product product);
    }
}
