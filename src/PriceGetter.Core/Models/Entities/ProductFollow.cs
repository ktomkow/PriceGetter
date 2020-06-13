using PriceGetter.Core.BaseClasses.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.Entities
{
    public class ProductFollow : EntityBase
    {
        public Guid ProductId { get; }
        public Guid SellerId { get; }
        public bool IsActive { get; protected set; }

        protected ProductFollow() : base() { }

        public ProductFollow(Guid productId, Guid sellerId) : base()
        {
            this.ProductId = productId;
            this.SellerId = sellerId;
            this.IsActive = true;
        }

        public ProductFollow(Guid productId, Guid sellerId, bool isActive) : base()
        {
            this.ProductId = productId;
            this.SellerId = sellerId;
            this.IsActive = isActive;
        }

        public void Activate()
        {
            this.IsActive = true;
        }

        public void Deactivate()
        {
            this.IsActive = false;
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
