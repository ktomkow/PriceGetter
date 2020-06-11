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
        public Money Extract(Html html)
        {
            string regex = "iVazGO.>.+ zł<\\/div>";
            string dirtyValue = Regex.Match(html.RawContent, regex).Value;
            dirtyValue = dirtyValue.RemoveChar(' ');

            string priceString = Regex.Match(dirtyValue, @"\d{1,10},\d{2}").Value.Replace(',', '.');

            decimal priceDecimal = priceString.ToDecimal(priceString);

            Money price = new Money(priceDecimal);

            return price;
        }
    }
}
