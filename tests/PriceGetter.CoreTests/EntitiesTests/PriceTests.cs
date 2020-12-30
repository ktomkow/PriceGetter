using System;
using FluentAssertions;
using NSubstitute;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using Xunit;

namespace PriceGetter.CoreTests.EntitiesTests
{
    public class PriceTests
    {
        private readonly Product product;

        private readonly IDateTimeProvider dateTimeProvider;

        private readonly DateTime sampleDateTime = new DateTime(2019, 10, 25, 10, 25, 59);

        public PriceTests()
        {
            this.product = GetProduct();
            this.dateTimeProvider = Substitute.For<IDateTimeProvider>();
            this.dateTimeProvider.UtcNow().Returns(sampleDateTime);

            DateTimeMethods.OverrideDateTimeProvider(this.dateTimeProvider);
        }

        [Fact]
        public void Ctor_IfProductIsNull_ShouldThrowException()
        {
            Action act = () =>
            {
                Price price = new Price(new Money(10.0m), null);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Ctor_IfAmountIsNull_ShouldThrowException()
        {
            Action act = () =>
            {
                Price price = new Price(null, this.product);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Ctor_At_ShouldBeUtcNow()
        {
            DateTime expectedAt = this.sampleDateTime;
            Price price = new Price(new Money(10.25m), this.product);
            
            price.At.Should().Be(expectedAt);
        }

        private Product GetProduct()
        {
            Name name = new Name("Sample name");
            Url productPage = Url.FromString(string.Empty);

            Product product = new Product(name, productPage);

            return product;
        }
    }
}