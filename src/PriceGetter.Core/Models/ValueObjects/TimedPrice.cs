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
            this.At = new DateTime(at.Year, at.Month, at.Day, at.Hour, at.Minute, 0);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 1827809;

                hash = hash * 382883 + this.Amount.GetHashCode();
                hash = hash * 382883 + this.At.GetHashCode();

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            TimedPrice instance = obj as TimedPrice;
            if (instance is null)
            {
                return false;
            }

            return this.Amount == instance.Amount && this.At == instance.At;
        }
    }
}
