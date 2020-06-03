using FluentAssertions;
using PriceGetter.Core.Implementations;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.ExtractorsTests
{
    public class PriceExtractorXkomTests
    {
        private readonly IPriceExtractor priceExtractor;

        public PriceExtractorXkomTests()
        {
            this.priceExtractor = new PriceExtractorXkom();
        }
        
        [Fact]
        public void Extract_When_3299p0_Then_3299p0()
        {
            string source = "<meta property=\"product: price: amount\" content=\"3299.00\" data-react-helmet=\"true\" />";
            Money expectedPrice = new Money(3299.0m);

            Money obtainedMoney = this.priceExtractor.Extract(source);

            obtainedMoney.Should().Be(expectedPrice);
        }

        [Fact]
        public void Extract_When_599p0_Then_599p0()
        {
            string source = "<meta property=\"product: price: amount\" content=\"599.00\" data-react-helmet=\"true\" />";
            Money expectedPrice = new Money(599.0m);

            Money obtainedMoney = this.priceExtractor.Extract(source);

            obtainedMoney.Should().Be(expectedPrice);
        }

        [Fact]
        public void Extract_When_1000p50_Then_1000p50()
        {
            string source = "<meta property=\"product: price: amount\" content=\"1000.50\" data-react-helmet=\"true\" />";
            Money expectedPrice = new Money(1000.50m);

            Money obtainedMoney = this.priceExtractor.Extract(source);

            obtainedMoney.Should().Be(expectedPrice);
        }
    }
}
