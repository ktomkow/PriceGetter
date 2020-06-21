using PriceGetter.ApplicationServices.PriceProviders.Sellers;
using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.ContentProvider.PriceExtractors;
using PriceGetter.Core.Entities;
using PriceGetter.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.ApplicationServices.PriceProviders
{
    public class PriceProviderFactory : IPriceProviderFactory
    {
        private readonly IHtmlContentGetter htmlContentGetter;
        private readonly PriceExtractorXkom xkomPriceExtractor;

        public PriceProviderFactory(
            IHtmlContentGetter htmlContentGetter,
            PriceExtractorXkom xkomPriceExtractor)
        {
            this.htmlContentGetter = htmlContentGetter;
            this.xkomPriceExtractor = xkomPriceExtractor;
        }

        public IPriceProvider GetProvider(Seller seller)
        {
            // so far this is the only supported seller
            return new XKomPriceProvider(this.htmlContentGetter, this.xkomPriceExtractor);
        }
    }
}
