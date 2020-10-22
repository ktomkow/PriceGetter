using PriceGetter.ContentProvider.DataExtractors.Xkom;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors.Xkom;
using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Interfaces.DataProviders.Xkom;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.DataProviders.Xkom
{
    public class XKomNameProvider : HtmlDataProviderBase, IXkomNameProvider
    {
        private readonly INameExtractor nameExtractor;

        public XKomNameProvider(IXkomNameExtractor nameExtractor, IHtmlContentGetter htmlContentGetter, ICacheFacade cacheFacade) : base(htmlContentGetter, cacheFacade)
        {
            this.nameExtractor = nameExtractor;
        }

        public async Task<Name> GetName(Url productPage)
        {
            if (productPage is null)
            {
                throw new ArgumentNullException(nameof(productPage));
            }

            Html html = await this.TakeThroughCache(productPage);

            Name productName = this.nameExtractor.Extract(html);

            return productName;
        }
    }
}
