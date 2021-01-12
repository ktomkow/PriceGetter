using FluentAssertions;
using PriceGetter.ContentProvider.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Models.ValueObjects;
using Xunit;

namespace PriceGetter.ContentProvidersTests.PriceExtractors
{
    public class CssPriceExtractorTests
    {
        private readonly ICssPriceExtractor priceExtractor;

        public CssPriceExtractorTests()
        {
            ICssContentExtractor cssContentExtractor = new BasicCssExtractor();

            this.priceExtractor = new CssPriceExtractor(cssContentExtractor);
        }

        [Fact]
        public void Extract_When_1000p50_Then_1000p50()
        {
            string source = "<div class=\"Dupa\">1000,50 zł</div>";
            Money expectedPrice = new Money(1000.50m);
            Html html = new Html(source);
            CssClass cssClass = new CssClass("Dupa");

            Money obtainedMoney = this.priceExtractor.Extract(html, cssClass);

            obtainedMoney.Should().Be(expectedPrice);
        }

        [Fact]
        public void Extract()
        {
            string source = "<div class=\"Dupa\">19 299,00 zł</div>";

            Money expectedPrice = new Money(19299.00m);
            Html html = new Html(source);

            CssClass cssClass = new CssClass("Dupa");

            Money obtainedMoney = this.priceExtractor.Extract(html, cssClass);

            obtainedMoney.Should().Be(expectedPrice);
        }
    }
}
