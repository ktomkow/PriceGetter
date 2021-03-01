using FluentAssertions;
using PriceGetter.ContentProvider.DataExtractors;
using PriceGetter.Core.Models.ValueObjects;
using Xunit;

namespace PriceGetter.ContentProvidersTests.NameExtraction
{
    public class BasicCssNameExtractorTests
    {
        private readonly BasicCssExtractor extractor;

        public BasicCssNameExtractorTests()
        {
            this.extractor = new BasicCssExtractor();
        }

        [Fact]
        public void NormalName()
        {
            string expectedName = "Super phone";
            string cssClass = "cc-d01 a38";
            string html = $"<div class=\"d0-c 12\"><h1 class=\"{cssClass}\">{expectedName}</h1></div>";

            string result = extractor.Extract(new Html(html), new CssClass(cssClass));

            result.Should().Be("Super phone");
        }

        [Fact]
        public void NameWithQuot()
        {
            string expectedName = "Super disk 2,5&quot; turbo";
            string cssClass = "cc-d01 a38";
            string html = $"<div class=\"d0-c 12\"><h1 class=\"{cssClass}\">{expectedName}</h1></div>";

            string result = extractor.Extract(new Html(html), new CssClass(cssClass));

            result.Should().Be("Super disk 2,5\" turbo");
        }
    }
}
