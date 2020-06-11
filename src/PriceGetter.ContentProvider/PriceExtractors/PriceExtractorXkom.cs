using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Core.SimpleTypesConverters.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PriceGetter.ContentProvider.PriceExtractors
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
