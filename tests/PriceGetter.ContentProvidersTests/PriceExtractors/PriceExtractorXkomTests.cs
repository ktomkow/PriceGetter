using FluentAssertions;
using PriceGetter.ContentProvider.CssExtractors;
using PriceGetter.ContentProvider.PriceExtractors;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.ContentProvider.PriceExtractors
{
    public class PriceExtractorXkomTests
    {
        private readonly PriceExtractorXkom priceExtractor;

        public PriceExtractorXkomTests()
        {
            ICssContentExtractor cssContentExtractor = new BasicCssExtractor();
            ICssPriceExtractor priceExtractor = new CssPriceExtractor(cssContentExtractor);
            this.priceExtractor = new PriceExtractorXkom(priceExtractor);
        }

        [Fact]
        public void Extract_When_3299p00_Then_3299p0()
        {
            string source = "<div class=\"u7xnnm-1 gIldPo\"><div class=\"u7xnnm-4 iVazGO\">3 299,00 zł</div></div>";
            Money expectedPrice = new Money(3299.0m);
            Html html = new Html(source);

            Money obtainedMoney = this.priceExtractor.Extract(html);

            obtainedMoney.Should().Be(expectedPrice);
        }

        [Fact]
        public void Extract_When_599p00_Then_599p0()
        {
            string source = "<div class=\"u7xnnm-1 gIldPo\"><div class=\"u7xnnm-4 iVazGO\">599,00 zł</div></div>";
            Money expectedPrice = new Money(599.0m);
            Html html = new Html(source);

            Money obtainedMoney = this.priceExtractor.Extract(html);

            obtainedMoney.Should().Be(expectedPrice);
        }

        [Fact]
        public void Extract_When_1000p50_Then_1000p50()
        {
            string source = "<div class=\"u7xnnm-1 gIldPo\"><div class=\"u7xnnm-4 iVazGO\">1000,50 zł</div></div>";
            Money expectedPrice = new Money(1000.50m);
            Html html = new Html(source);

            Money obtainedMoney = this.priceExtractor.Extract(html);

            obtainedMoney.Should().Be(expectedPrice);
        }
    }
}
