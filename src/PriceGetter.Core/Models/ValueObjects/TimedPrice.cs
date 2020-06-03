using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class TimedPrice : ValueObjectBase
    {
        public Money Value { get; }
        public DateTime At { get; }

        protected TimedPrice() { }

        public TimedPrice(Money price) : this(price, DateTime.Now) { }

        public TimedPrice(Money price, DateTime at)
        {
            this.Value = price;
            this.At = at;
        }
    }
}
