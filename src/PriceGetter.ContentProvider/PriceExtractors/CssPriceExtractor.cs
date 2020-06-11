using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Core.SimpleTypesConverters.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PriceGetter.ContentProvider.PriceExtractors
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
