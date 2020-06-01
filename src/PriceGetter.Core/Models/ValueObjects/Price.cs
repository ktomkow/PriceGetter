using PriceGetter.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Price : PriceBase
    {
        protected Price() : base() { }

        public Price(decimal price) : base(price) { }

        protected override bool IsPriceValid(decimal price)
        {
            return price >= 0;
        }
    }
}
