using FluentAssertions;
using PriceGetter.ContentProvider.DataExtractors.Xkom;
using PriceGetter.Core.Models.ValueObjects;
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
            string rawHtml = "<div class=\"sc-2ow6xm-5 dPFuqj\"><div class=\"sc-2ow6xm-6 dQiNgR\"><div class=\"sc-2ow6xm-0 jdsbUs\"><div><div class=\"sc-2ow6xm-10 bHyXlv\"><span class=\"sc-1tblmgq-0 sc-2ow6xm-1 eATWME sc-1tblmgq-2 jujzsL\"><img src=\"https://dupa.jpg\" alt=\"Intel Core i5-10600KF - 564447 - zdjęcie 1\" class=\"sc-1tblmgq-1 grqydx\"/></span></div></div></div></div><div";

            Html html = new Html(rawHtml);

            Url url = extractor.Extract(html);

            url.Should().Be(expectedUrl);
        }
    }
}
