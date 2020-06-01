using FluentAssertions;
using PriceGetter.Core.Models;
using PriceGetter.Core.Models.ValueObjects;
using System;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests
{
    public class PriceTests
    {
        [Fact]
        public void WhenPrice9p99_Then_Value9p99()
        {
            decimal originalPrice = 9.99m;
            decimal expectedPrice = 9.99m;

            Price price = new Price(originalPrice);
            decimal obtainedPrice = price.Value;

            obtainedPrice.Should().Be(expectedPrice);
        }

        [Fact]
        public void WhenPrice9p9900_Then_Value9p99()
        {
            decimal originalPrice = 9.9900m;
            decimal expectedPrice = 9.99m;

            Price price = new Price(originalPrice);
            decimal obtainedPrice = price.Value;

            obtainedPrice.Should().Be(expectedPrice);
        }

        //[Fact]
        //public void WhenPrice9p991_Then_Value9p99() // TODO: TESTY ZAOKR¥GLANIA
        //{
        //    decimal originalPrice = 9.991m;
        //    decimal expectedPrice = 9.99m;

        //    Price price = new Price(originalPrice);
        //    decimal obtainedPrice = price.Value;

        //    obtainedPrice.Should().Be(expectedPrice);
        //}

        [Fact]
        public void WhenPrice0_Then_Value0p00()
        {
            decimal originalPrice = 0m;
            decimal expectedPrice = 0.00m;

            Price price = new Price(originalPrice);
            decimal obtainedPrice = price.Value;

            obtainedPrice.Should().Be(expectedPrice);
        }
        
        [Fact]
        public void WhenPriceFewerThan0_Then_ArgumentException()
        {
            decimal originalPrice = -0.12m;

            Action act = () =>
            {
                Price price = new Price(originalPrice);
            };

            act.Should().Throw<ArgumentException>();
        }
    }
}
