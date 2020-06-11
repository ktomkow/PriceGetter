using FluentAssertions;
using PriceGetter.ContentProvider.NameExtractors;
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
            this.extractor = new NameExtractorXkom();
        }

        [Fact]
        public void a()
        {
            Name expectedName = new Name("Switch Mario Kart 8 Deluxe");
            string rawHtml = "";
            Html html = new Html(rawHtml);

            Name name = extractor.Extract(html);

            name.Should().Be(expectedName);
        }
    }
}
