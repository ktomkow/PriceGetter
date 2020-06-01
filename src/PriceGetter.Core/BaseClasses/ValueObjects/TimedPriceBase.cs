using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.ValueObjects
{
    public abstract class TimedPriceBase
    {
        public PriceBase Value { get; }
        public DateTime At { get; }

        protected TimedPriceBase() { }

        public TimedPriceBase(PriceBase price) : this(price, DateTime.Now) { }

        public TimedPriceBase(PriceBase price, DateTime at)
        {
            this.Value = price;
            this.At = at;
        }
    }
}
