using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Entities;
using PriceGetter.Core.Models.ValueObjects;
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
        public Url ProductPage { get; set; }

        protected ProductFollow() : base() { }

        public ProductFollow(Product product, Seller seller, Url productPage) : base()
        {
            this.ProductId = product.Id;
            this.SellerId = seller.Id;
            this.ProductPage = productPage;
            this.IsActive = true;
        }

        public ProductFollow(Product product, Seller seller, Url productPage, bool isActive) : base()
        {
            this.ProductId = product.Id;
            this.SellerId = seller.Id;
            this.ProductPage = productPage;
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
