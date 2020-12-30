using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;

namespace PriceGetter.Core.Models.Entities
{
    public class Price : EntityBase
    {
        public Money Amount { get; }
        public DateTime At { get; }
        public Product Product { get; }

        public decimal AmountAsDecimal { get => this.Amount.ValueAsDecimal; }

        protected Price() 
        {
            this.At = DateTime.UtcNow;
        }

        public Price(Money amount, Product product) : this()
        {
            this.Amount = amount;
            this.Product = product;
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
            throw new NotImplementedException();
        }
    }
}
