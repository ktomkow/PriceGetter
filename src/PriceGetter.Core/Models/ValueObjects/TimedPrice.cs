using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class TimedPrice : ValueObjectBase
    {
        public Money Amount { get; }
        public DateTime At { get; }

        protected TimedPrice() { }

        public TimedPrice(Money price) : this(price, DateTime.UtcNow) { }

        public TimedPrice(Money price, DateTime at)
        {
            this.Amount = price;
            this.At = at;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
