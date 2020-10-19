using PriceGetter.ContentProvider.DataExtractors.Xkom;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.DataProviders.Xkom
{
    public class XKomImageProvider : HtmlDataProvider, IImageUrlProvider
    {
        private readonly IMainImageExtractor imageExtractor;

        public XKomImageProvider(MainImageExtractorXkom imageExtractor, IHtmlContentGetter htmlContentGetter, ICacheFacade cache) : base(htmlContentGetter, cache)
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
