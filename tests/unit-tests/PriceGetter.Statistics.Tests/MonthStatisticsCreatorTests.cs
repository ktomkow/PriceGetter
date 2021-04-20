using FluentAssertions;
using NSubstitute;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Statistics.Products.DefaultImplementation;
using PriceGetter.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PriceGetter.Statistics.Tests
{
    public class MonthStatisticsCreatorTests
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly MonthStatisticsCreator creator;

        public MonthStatisticsCreatorTests()
        {
            this.creator = new MonthStatisticsCreator();
            this.dateTimeProvider = Substitute.For<IDateTimeProvider>();
        }

        [Fact]
        public void Create_WhenProductNull_ThenThrowArgumentNullException()
        {
            Product product = null;

            Action act = () =>
            {
                IEnumerable<MonthStatistics> result = this.creator.Create(product);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Create_WhenProductHasNoPrice_ThenReturnEmptyCollection()
        {
            Product product = this.GetSampleProduct();

            IEnumerable<MonthStatistics> result = this.creator.Create(product);

            result.Should().BeEmpty();
        }

        [Fact]
        public void Create_WhenOnlyOnePrice_ThenMinAndMaxPriceSame()
        {
            Product product = this.GetSampleProduct();
            product.AddPrice(new Money(19.99m));

            IEnumerable<MonthStatistics> result = this.creator.Create(product);

            result.Should().HaveCount(1);
            result.First().MaxPrice.Should().Be(result.First().MinPrice).And.Be(new Money(19.99m));
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public void Create_WhenTwoPricesSameMonth_ThenOneObjectButDifferentPrices()
        {
            Product product = this.GetSampleProduct();
            Money firstAmount = new Money(19.99m);
            Money secondAmount = new Money(1921.21m);

            this.SetDateTime(new DateTime(2019, 2, 23));
            product.AddPrice(firstAmount);

            this.SetDateTime(new DateTime(2019, 2, 26));
            product.AddPrice(secondAmount);

            IEnumerable<MonthStatistics> result = this.creator.Create(product);

            result.Should().HaveCount(1);
            result.First().MinPrice.Should().Be(firstAmount);
            result.First().MaxPrice.Should().Be(secondAmount);
            result.First().Year.Should().Be(2019);
            result.First().Month.Should().Be(2);
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public void Create_WhenThreePricesSameMonth_ThenOneObjectButCorrectPrices()
        {
            Product product = this.GetSampleProduct();
            Money minPrice = new Money(10m);
            Money averagePrice = new Money(11.95m);
            Money maxPrice = new Money(19.99m);

            this.SetDateTime(new DateTime(2019, 2, 23));
            product.AddPrice(minPrice);

            this.SetDateTime(new DateTime(2019, 2, 26));
            product.AddPrice(averagePrice);

            this.SetDateTime(new DateTime(2019, 2, 27));
            product.AddPrice(maxPrice);

            IEnumerable<MonthStatistics> result = this.creator.Create(product);

            result.Should().HaveCount(1);
            result.First().MinPrice.Should().Be(minPrice);
            result.First().MaxPrice.Should().Be(maxPrice);
            result.First().Year.Should().Be(2019);
            result.First().Month.Should().Be(2);
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public void Create_WhenTwoPricesOtherMonth_ThenTwoElementsCollection()
        {
            Product product = this.GetSampleProduct();
            Money firstPrice = new Money(10m);
            Money secondPrice = new Money(11.95m);

            this.SetDateTime(new DateTime(2019, 2, 23));
            product.AddPrice(firstPrice);

            this.SetDateTime(new DateTime(2019, 3, 9));
            product.AddPrice(secondPrice);

            IEnumerable<MonthStatistics> result = this.creator.Create(product);

            result.Should().HaveCount(2);

            result.Single(x => x.Month == 2).MinPrice.Should().Be(firstPrice);
            result.Single(x => x.Month == 2).MaxPrice.Should().Be(firstPrice);

            result.Single(x => x.Month == 3).MinPrice.Should().Be(secondPrice);
            result.Single(x => x.Month == 3).MaxPrice.Should().Be(secondPrice);
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public void Create_WhenThreePricesTwoMonths_ThenTwoElementsCollection()
        {
            Product product = this.GetSampleProduct();
            Money firstPrice = new Money(10m);
            Money secondPrice = new Money(11.95m);
            Money thirdPrice = new Money(13.95m);

            this.SetDateTime(new DateTime(2019, 2, 23));
            product.AddPrice(firstPrice);

            this.SetDateTime(new DateTime(2019, 2, 25));
            product.AddPrice(secondPrice);

            this.SetDateTime(new DateTime(2019, 3, 9));
            product.AddPrice(thirdPrice);

            IEnumerable<MonthStatistics> result = this.creator.Create(product);

            result.Should().HaveCount(2);

            result.Single(x => x.Month == 2).MinPrice.Should().Be(firstPrice);
            result.Single(x => x.Month == 2).MaxPrice.Should().Be(secondPrice);

            result.Single(x => x.Month == 3).MinPrice.Should().Be(thirdPrice);
            result.Single(x => x.Month == 3).MaxPrice.Should().Be(thirdPrice);
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public void Create_WhenFourPricesTwoMonthsThreePricesSameMonth_ThenTwoElementsCollection()
        {
            Product product = this.GetSampleProduct();
            Money firstPrice = new Money(10m);
            Money secondPrice = new Money(11.95m);
            Money thirdPrice = new Money(13.95m);
            Money fourthPrice = new Money(28.3m);

            this.SetDateTime(new DateTime(2019, 2, 23));
            product.AddPrice(firstPrice);

            this.SetDateTime(new DateTime(2019, 2, 25));
            product.AddPrice(secondPrice);

            this.SetDateTime(new DateTime(2019, 2, 26));
            product.AddPrice(thirdPrice);

            this.SetDateTime(new DateTime(2019, 3, 9));
            product.AddPrice(fourthPrice);

            IEnumerable<MonthStatistics> result = this.creator.Create(product);

            result.Should().HaveCount(2);

            result.Single(x => x.Month == 2).MinPrice.Should().Be(firstPrice);
            result.Single(x => x.Month == 2).MaxPrice.Should().Be(thirdPrice);

            result.Single(x => x.Month == 3).MinPrice.Should().Be(fourthPrice);
            result.Single(x => x.Month == 3).MaxPrice.Should().Be(fourthPrice);
        }

        private Product GetSampleProduct()
        {
            return new Product(new Name("SampleName"), new EmptyUrl());
        }

        private void SetDateTime(DateTime dateTime)
        {
            this.dateTimeProvider.UtcNow().Returns(dateTime);
            DateTimeMethods.OverrideDateTimeProvider(this.dateTimeProvider);
        }
    }
}
