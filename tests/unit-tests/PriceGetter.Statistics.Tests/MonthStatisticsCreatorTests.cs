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
