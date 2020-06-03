using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests
{
    public class TimedPriceTests
    {
        [Fact]
        public void WhenPrice9p99_Then_Value9p99()
        {
            Money originalPrice = new Money(9.99m);
            Money expectedPrice = new Money(9.99m);

            TimedPrice timedPrice = new TimedPrice(originalPrice);

            timedPrice.Value.Should().Be(expectedPrice);
            timedPrice.Value.Value.Should().Be(9.99m);
        }
    }
}
