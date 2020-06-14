using FluentAssertions;
using PriceGetter.ContentProvider.CssExtractors;
using PriceGetter.ContentProvider.ImagesUrlExtractors;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.ContentProvidersTests.MainImagesExtractors
{
    public class MainImageExtractorXkomTests
    {
        private readonly MainImageExtractorXkom extractor;

        public MainImageExtractorXkomTests()
        {
            this.extractor = new MainImageExtractorXkom();
        }

        [Fact]
        public void ExtractFromSingleElement()
        {
            Url expectedUrl = new Url("https://dupa.jpg");
            string rawHtml = "<span class=\"sc-1tblmgq-0 sc-1y93ua6-0 lodfKm sc-1tblmgq-2 bIcxIH\"><img src=\"https://dupa.jpg\" alt=\"Some product main picture\" class=\"sc-1tblmgq-1 bxjRuC\"/></span>";
            Html html = new Html(rawHtml);

            Url url = extractor.Extract(html);

            url.Should().Be(expectedUrl);
        }
    }
}
