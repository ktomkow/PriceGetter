using System;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class MonthStatistics
    {
        public Money MaxPrice { get; }

        public Money MinPrice { get; }

        public int Month { get; }

        public int Year { get; }

        public MonthStatistics(Money minPrice, Money maxPrice, int month, int year)
        {
            if (maxPrice >= minPrice)
            {
                this.MaxPrice = maxPrice ?? throw new ArgumentNullException(nameof(maxPrice));
                this.MinPrice = minPrice ?? throw new ArgumentNullException(nameof(minPrice));
            }
            else
            {
                this.MaxPrice = minPrice ?? throw new ArgumentNullException(nameof(minPrice));
                this.MinPrice = maxPrice ?? throw new ArgumentNullException(nameof(maxPrice));
            }

            this.EnsureMonthIsValid(month);
            this.EnsureYearIsValid(year);

            this.Month = month;
            this.Year = year;
        }

        private void EnsureMonthIsValid(int month)
        {
            if(month > 12 || month < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(month), month, "Month ouf of range 1..12");
            }
        }

        private void EnsureYearIsValid(int year)
        {
            if (year > 2099 || year < 2000)
            {
                throw new ArgumentOutOfRangeException(nameof(year), year, "Month ouf of range 2000..2099");
            }
        }
    }
}
