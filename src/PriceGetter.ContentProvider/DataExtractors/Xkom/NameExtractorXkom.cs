using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.ContentProvider.DataExtractors.Xkom
{
    public class NameExtractorXkom : INameExtractor
    {
        private readonly ICssContentExtractor cssContentExtractor;

        public NameExtractorXkom(ICssContentExtractor cssContentExtractor)
        {
            this.cssContentExtractor = cssContentExtractor;
        }

        public Name Extract(Html html)
        {
            CssClass cssClass = new CssClass("sc-1x6crnh-5 gOwOoL");

            string rawName = this.cssContentExtractor.Extract(html, cssClass);

            Name name = new Name(rawName);

            return name;
        }
    }
}
