using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.ApplicationServices.SpecificDetailsProviders.Sellers;
using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.WebClients;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders
{
    public class SpecificDetailsProviderFactory : ISpecificDetailsProviderFactory
    {
        private readonly IHtmlContentGetter htmlGetter;

        public SpecificDetailsProviderFactory(IHtmlContentGetter htmlGetter)
        {
            this.htmlGetter = htmlGetter;
        }

        public ISpecificDetailsProvider Get(string url)
        {
            if(url.ToLowerInvariant().Trim().Contains("www.x-kom.pl"))
            {
                return new XkomDetailsProvider(this.htmlGetter);
            }

            throw new InvalidOperationException("This seller is not supported.");
        }
    }
}
