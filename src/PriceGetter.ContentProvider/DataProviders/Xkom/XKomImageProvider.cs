using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors.Xkom;
using PriceGetter.Core.Interfaces.DataProviders.Xkom;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.DataProviders.Xkom
{
    public class XKomImageProvider : HtmlDataProviderBase, IXkomImageUrlProvider
    {
        private readonly IMainImageExtractor imageExtractor;

        public XKomImageProvider(IXkomImageUrlExtractor imageExtractor, IHtmlContentGetter htmlContentGetter, ICacheFacade cache) : base(htmlContentGetter, cache)
        {
            this.imageExtractor = imageExtractor;
        }

        public async Task<Url> GetImageUrl(Url productPage)
        {
            if(productPage is null)
            {
                throw new ArgumentNullException(nameof(productPage));
            }

            Html html = await this.TakeThroughCache(productPage);

            Url imageUrl = this.imageExtractor.Extract(html);

            return imageUrl;
        }
    }
}
