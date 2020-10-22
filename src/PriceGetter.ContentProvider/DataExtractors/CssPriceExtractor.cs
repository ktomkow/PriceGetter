using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Core.SimpleTypesConverters.Extensions;

namespace PriceGetter.ContentProvider.DataExtractors
{
    public class CssPriceExtractor : ICssPriceExtractor
    {
        private readonly ICssContentExtractor cssExtractor;

        public CssPriceExtractor(ICssContentExtractor cssContentExtractor)
        {
            this.cssExtractor = cssContentExtractor;
        }

        public Money Extract(Html html, CssClass cssClass)
        {
            string rawContent = this.cssExtractor.Extract(html, cssClass);

            decimal rawMoney = rawContent.ToDecimal();

            Money money = new Money(rawMoney);

            return money;
        }
    }
}
