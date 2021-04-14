using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects;
using Xunit;

namespace PriceGetter.Statistics.Tests.Domain
{
    public class MonthStatisticsTests
    {
        [Fact]
        public void Ctor_WhenMinPriceSameAsMaxPrice_ThenBothSame () 
        {
            Money minPrice = new Money(10.0m);
            Money maxPrice = new Money(10.0m);

            int year = 2010;
            int month = 11;

            MonthStatistics statistics = new MonthStatistics(maxPrice, minPrice, month, year);

            statistics.MaxPrice.Should().Be(statistics.MinPrice);
            statistics.MaxPrice.Should().Be(maxPrice);
            statistics.MinPrice.Should().Be(minPrice);
        }
    }
}
