using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Price : ValueObjectBase
    {
        public Money Amount { get; }
        public DateTime At { get; }

        protected Price() { }

        public Price(Money price) : this(price, DateTime.UtcNow) { }

        public Price(Money price, DateTime at)
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
            Price instance = obj as Price;
            if (instance is null)
            {
                return false;
            }

            return this.Amount == instance.Amount && this.At == instance.At;
        }
    }
}
