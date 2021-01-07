using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.Core.Models.ValueObjects;
using System;

namespace PriceGetter.Core.Models.Entities
{
    public class Price : EntityBase, IEquatable<Price>
    {
        public Money Amount { get; private set; }

        public DateTime At { get; private set; }

        public Product Product { get; private set; }

        public decimal AmountAsDecimal { get => this.Amount.ValueAsDecimal; }

        protected Price()
        {
            
        }

        public Price(Money amount, Product product)
        {
            this.Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            this.Product = product ?? throw new ArgumentNullException(nameof(product));
            this.At = DateTimeMethods.UtcNow();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 48383;

                hash = hash * 476981 + this.At.GetHashCode();
                hash = hash * 476981 + this.Amount.GetHashCode();
                hash = hash * 476981 + this.Product.Name.GetHashCode();

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Price priceInstance = obj as Price;
            if (priceInstance == null)
            {
                return false;
            }

            return Equals(priceInstance);
        }

        public bool Equals(Price other)
        {
            if (other == null)
            {
                return false;
            }

            if(other == this)
            {
                return true;
            }

            return this.Product.Equals(other.Product)
                   && this.At.Equals(other.At)
                   && this.Amount.Equals(other.Amount);
        }
    }
}
