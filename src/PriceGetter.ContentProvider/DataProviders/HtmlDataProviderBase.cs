using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.DataProviders
{
    internal abstract class HtmlDataProviderBase
    {
        protected readonly IHtmlContentGetter htmlContentGetter;
        protected readonly ICacheFacade cacheFacade;

        public HtmlDataProviderBase(IHtmlContentGetter htmlContentGetter, ICacheFacade cacheFacade)
        {
            this.htmlContentGetter = htmlContentGetter ?? throw new ArgumentNullException(nameof(htmlContentGetter));
            this.cacheFacade = cacheFacade ?? throw new ArgumentNullException(nameof(cacheFacade));
        }

        protected virtual async Task<Html> TakeThroughCache(Url productPage)
        {
            Html html = this.cacheFacade.Get<Html>(productPage);
            if (html is null)
            {
                html = await this.htmlContentGetter.GetAsync(productPage);
                this.cacheFacade.Save<Html>(html, productPage);
            }

            return html;
        }
    }
}
