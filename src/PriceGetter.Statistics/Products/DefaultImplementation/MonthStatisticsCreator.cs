using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
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

            if (product.Prices.Count() == 1)
            {
                Price price = product.GetLastPrice();
                return new[] { new MonthStatistics(price.Amount, price.Amount, price.At.Month, price.At.Year) };
            }

            List<MonthStatistics> list = new List<MonthStatistics>();

            Money maxPrice = product.Prices.Max(x => x.Amount);
            Money minPrice = product.Prices.Min(x => x.Amount);
            DateTime date = product.Prices.First().At;

            list.Add(new MonthStatistics(minPrice, maxPrice, date.Month, date.Year));

            return list;
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
