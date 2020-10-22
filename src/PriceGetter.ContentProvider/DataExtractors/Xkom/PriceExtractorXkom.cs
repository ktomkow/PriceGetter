using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.ContentProvider.DataExtractors.Xkom
{
    public class PriceExtractorXkom : IPriceExtractor
    {
        private readonly ICssPriceExtractor cssExtractor;

        public PriceExtractorXkom(ICssPriceExtractor cssPriceExtractor)
        {
            this.cssExtractor = cssPriceExtractor;
        }

        public Money Extract(Html html) 
        {
            CssClass cssClass = new CssClass("u7xnnm-4 iVazGO");

            Money productPrice = this.cssExtractor.Extract(html, cssClass);

            return productPrice;
        }
    }
}
