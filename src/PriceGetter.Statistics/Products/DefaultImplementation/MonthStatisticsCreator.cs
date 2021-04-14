using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Statistics.Products.Interfaces;
using System.Collections.Generic;

namespace PriceGetter.Statistics.Products.DefaultImplementation
{
    public class MonthStatisticsCreator : IMonthStatisticsCreator
    {
        public IEnumerable<MonthStatistics> Create(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
