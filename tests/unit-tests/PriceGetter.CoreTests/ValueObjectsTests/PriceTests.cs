﻿using FluentAssertions;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests
{
    public class PriceTests
    {
        [Fact]
        public void GetHashCode_ShouldBeImplemented()
        {
            Url emptyUrl = Url.FromString(string.Empty);
            Name sampleName = new Name("Sample");
            Product product = new Product(sampleName, emptyUrl);

            Money money = new Money(10.00m);
            Price price = new Price(money, product);

            Action act = () =>
            {
                price.GetHashCode();
            };

            act.Should().NotThrow();
        }
    }
}
