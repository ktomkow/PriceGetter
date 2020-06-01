using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.ValueObjects
{
    public abstract class PriceBase
    {
        public decimal Value { get; }

        protected PriceBase() { }

        public PriceBase(decimal price)
        {
            if (this.IsPriceValid(price))
            {
                this.Value = price;
            }
            else
            {
                throw new ArgumentException("Incorrect price", nameof(price));
            }
        }

        protected abstract bool IsPriceValid(decimal price);
    }
}
