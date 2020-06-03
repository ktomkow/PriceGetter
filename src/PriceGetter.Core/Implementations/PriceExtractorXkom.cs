using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PriceGetter.Core.Implementations
{
    public class PriceExtractorXkom : IPriceExtractor
    {
        private readonly string sliceRegex = "product:price:amount\" content=\"\\d+\\.\\d{2}\" data-react-helmet";
        private readonly string priceRegex = "\\d+\\.\\d{2}";


        public Money Extract(string html)
        {
            Match sourceSlice = Regex.Match(html, this.sliceRegex);

            if(sourceSlice.Success == false)
            {
                this.ThrowException();
            }

            Match priceMatch = Regex.Match(sourceSlice.Value, this.priceRegex);

            if(priceMatch.Success == false)
            {
                this.ThrowException();
            }

            string priceMatchValue = priceMatch.Value;
            decimal priceDecimal = Convert.ToDecimal(priceMatchValue);

            Money price = new Money(priceDecimal);

            return price;
        }

        private void ThrowException()
        {
            throw new ArgumentException($"Given source does not contain price or can't be handled by this extractor: {this.GetType().Name}");
        }
    }
}
