using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class TimedPrice : ValueObjectBase
    {
        public Price Value { get; }
        public DateTime At { get; }

        protected TimedPrice() { }

        public TimedPrice(Price price) : this(price, DateTime.Now) { }

        public TimedPrice(Price price, DateTime at)
        {
            this.Value = price;
            this.At = at;
        }
    }
}
