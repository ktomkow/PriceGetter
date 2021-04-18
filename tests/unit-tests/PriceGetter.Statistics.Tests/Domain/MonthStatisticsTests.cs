using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects;
using System;
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

            MonthStatistics statistics = new MonthStatistics(minPrice, maxPrice, month, year);

            statistics.MaxPrice.Should().Be(statistics.MinPrice);
            statistics.MaxPrice.Should().Be(maxPrice);
            statistics.MinPrice.Should().Be(minPrice);
        }

        [Fact]
        public void Ctor_WhenPricesDifferentButCorrect_ThenShouldBeFine()
        {
            Money minPrice = new Money(9.0m);
            Money maxPrice = new Money(11.0m);

            int year = 2010;
            int month = 11;

            MonthStatistics statistics = new MonthStatistics(minPrice, maxPrice, month, year);

            statistics.MaxPrice.Should().Be(maxPrice);
            statistics.MinPrice.Should().Be(minPrice);
        }

        [Fact]
        public void Ctor_WhenPricesDifferentAndWrongOrder_ThenChangeOrder()
        {
            Money minPrice = new Money(90.0m);
            Money maxPrice = new Money(500.0m);

            int year = 2010;
            int month = 11;

            MonthStatistics statistics = new MonthStatistics(maxPrice, minPrice, month, year);

            statistics.MaxPrice.Should().Be(maxPrice);
            statistics.MinPrice.Should().Be(minPrice);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-12)]
        [InlineData(13)]
        [InlineData(20)]
        public void Ctor_WhenMonthOutOfRange_ThenThrowArgumentOutOfRangeException(int month)
        {
            Money minPrice = new Money(90.0m);
            Money maxPrice = new Money(500.0m);

            int year = 2010;

            Action act = () =>
            {
                MonthStatistics statistics = new MonthStatistics(maxPrice, minPrice, month, year);
            };

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1960)]
        [InlineData(1999)]
        [InlineData(20210)]
        [InlineData(3000)]
        [InlineData(2100)]
        public void Ctor_WhenYearOutOfRange_ThenThrowArgumentOutOfRangeException(int year)
        {
            Money minPrice = new Money(90.0m);
            Money maxPrice = new Money(500.0m);

            int month = 10;

            Action act = () =>
            {
                MonthStatistics statistics = new MonthStatistics(maxPrice, minPrice, month, year);
            };

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
