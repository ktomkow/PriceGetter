using FluentAssertions;
using PriceGetter.ContentProvider.CssExtractors;
using PriceGetter.ContentProvider.NameExtractors;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.ContentProvidersTests.NameExtractors
{
    public class NameExtractorXkomTests
    {
        private readonly NameExtractorXkom extractor;

        public NameExtractorXkomTests()
        {
            ICssContentExtractor cssContentExtractor = new BasicCssExtractor();
            this.extractor = new NameExtractorXkom(cssContentExtractor);
        }

        [Fact]
        public void ExtractFromSingleElement()
        {
            Name expectedName = new Name("Switch Mario Kart 8 Deluxe");
            string rawHtml = "<h1 class=\"sc-1x6crnh-5 gOwOoL\">Switch Mario Kart 8 Deluxe</h1>";
            Html html = new Html(rawHtml);

            Name name = extractor.Extract(html);

            name.Should().Be(expectedName);
        }

        [Fact]
        public void ExtractFromNestedElement()
        {
            Name expectedName = new Name("Switch Mario Kart 8 Deluxe");
            string rawHtml = "<div class=\"sc-1x6crnh-13 fXjZNH\"><h1 class=\"sc-1x6crnh-5 gOwOoL\">Switch Mario Kart 8 Deluxe</h1></div>";
            Html html = new Html(rawHtml);

            Name name = extractor.Extract(html);

            name.Should().Be(expectedName);
        }
    }
}
