using PriceGetter.Core.Exceptions.NotExtractable;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors.Xkom;
using PriceGetter.Core.Models.ValueObjects;
using System;

namespace PriceGetter.ContentProvider.DataExtractors.Xkom
{
    public class PriceExtractorXkom : IXkomPriceExtractor
    {
        private readonly ICssPriceExtractor cssExtractor;

        public PriceExtractorXkom(ICssPriceExtractor cssPriceExtractor)
        {
            this.cssExtractor = cssPriceExtractor;
        }

        public Money Extract(Html html) 
        {
            try
            {
                CssClass cssClass = new CssClass("u7xnnm-4 jFbqvs");

                Money productPrice = this.cssExtractor.Extract(html, cssClass);

                return productPrice;
            }
            catch (Exception)
            {
                throw new NotExtractableException(nameof(PriceExtractorXkom));
            }
        }
    }
}
