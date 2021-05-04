using PriceGetter.Core.Models.Entities;
using PriceGetter.Statistics.Domain;
using PriceGetter.Statistics.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceGetter.Statistics.Products.DefaultImplementation
{
    public class MonthStatisticsCreator : IMonthStatisticsCreator
    {
        public IEnumerable<MonthStatistics> Create(Product product)
        {
            this.EnsureProductNotNull(product);

            if (product.Prices.Any() == false)
            {
                return Enumerable.Empty<MonthStatistics>();
            }

            IEnumerable<MonthStatistics> statistics = product.Prices
                .Select(x => new
                {
                    month = x.At.Month,
                    year = x.At.Year,
                    amount = x.Amount
                })
                .ToLookup(x => (x.year, x.month))
                .Select(x => new MonthStatistics(x.Min(z => z.amount), x.Max(z => z.amount), x.Key.month, x.Key.year));
            
            return statistics;
        }

        private void EnsureProductNotNull(Product product)
        {
            if(product is null)
            {
                throw new ArgumentNullException(nameof(product), this.GetType().FullName);
            }
        }
    }
}
