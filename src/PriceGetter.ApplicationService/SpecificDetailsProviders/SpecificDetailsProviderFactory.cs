using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.ApplicationServices.SpecificDetailsProviders.Sellers;
using PriceGetter.ContentProvider.ImagesUrlExtractors;
using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.ContentProvider.NameExtractors;
using PriceGetter.ContentProvider.PriceExtractors;
using PriceGetter.WebClients;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders
{
    public class SpecificDetailsProviderFactory : ISpecificDetailsProviderFactory
    {
        private readonly IHtmlContentGetter htmlGetter;
        private readonly PriceExtractorXkom xkomPriceExtractor;
        private readonly NameExtractorXkom xkomNameExtractor;
        private readonly MainImageExtractorXkom mainImageExtractorXkom;

        public SpecificDetailsProviderFactory(
            IHtmlContentGetter htmlGetter
            ,PriceExtractorXkom priceExtractor
            ,NameExtractorXkom nameExtractor
            ,MainImageExtractorXkom mainImageExtractorXkom)
        {
            this.htmlGetter = htmlGetter;
            this.xkomPriceExtractor = priceExtractor;
            this.xkomNameExtractor = nameExtractor;
            this.mainImageExtractorXkom = mainImageExtractorXkom;
        }

        public ISpecificDetailsProvider Get(string url)
        {
            if(url.ToLowerInvariant().Trim().Contains("www.x-kom.pl"))
            {
                return new XkomDetailsProvider(
                    this.htmlGetter
                    ,this.xkomPriceExtractor
                    ,this.xkomNameExtractor
                    ,this.mainImageExtractorXkom);
            }

            throw new InvalidOperationException("This seller is not supported.");
        }
    }
}
