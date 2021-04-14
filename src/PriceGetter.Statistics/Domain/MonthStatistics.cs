using PriceGetter.Core.Models.ValueObjects;
using System;

namespace PriceGetter.Statistics.Domain 
{ 
    public class MonthStatistics
    {
        public Money MaxPrice { get; }

        public Money MinPrice { get; }

        public int Month { get; }

        public int Year { get; }

        public MonthStatistics(Money maxPrice, Money minPrice, int month, int year)
        {
            if (maxPrice >= minPrice)
            {
                this.MaxPrice = maxPrice ?? throw new ArgumentNullException(nameof(maxPrice));
                this.MinPrice = minPrice ?? throw new ArgumentNullException(nameof(minPrice));
            }
            else
            {
                this.MaxPrice = minPrice ?? throw new ArgumentNullException(nameof(maxPrice));
                this.MinPrice = maxPrice ?? throw new ArgumentNullException(nameof(minPrice));
            }

            this.Month = month;
            this.Year = year;
        }
    }
}
