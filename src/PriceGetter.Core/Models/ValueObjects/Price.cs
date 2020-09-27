using PriceGetter.Core.BaseClasses.ValueObjects;
using PriceGetter.Core.Entities;
using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Price : ValueObjectBase
    {
        public Money Amount { get; }
        public DateTime At { get; }
        public Guid SellerId { get; }
        public Guid ProductId { get; }

        public decimal AmountAsDecimal { get => this.Amount.ValuAsDecimal; }

        protected Price() { }

        public Price(Money price, Product product, Seller seller, DateTime at)
        {
            this.Amount = price;
            this.ProductId = product.Id;
            this.SellerId = seller.Id;
            this.At = new DateTime(at.Year, at.Month, at.Day, at.Hour, at.Minute, 0);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 1827809;

                hash = hash * 382883 + this.Amount.GetHashCode();
                hash = hash * 382883 + this.At.GetHashCode();
                hash = hash * 382883 + this.SellerId.GetHashCode();
                hash = hash * 382883 + this.ProductId.GetHashCode();

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

            bool isSameAmount = this.Amount == instance.Amount;
            bool isSameTime = this.At == instance.At;
            bool isSameProduct = this.ProductId == instance.ProductId;
            bool isSameSeller = this.SellerId == instance.SellerId;

            return isSameAmount && isSameAmount && isSameProduct && isSameSeller;
        }
    }
}
