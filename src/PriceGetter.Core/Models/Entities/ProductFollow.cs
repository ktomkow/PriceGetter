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
        public Url ProductPage { get; protected set; }
        public Url ProductImage { get; protected set; }

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

        public void UpdateProductPage(Url productPage)
        {
            this.ProductPage = productPage;
        }

        public void UpdateImageUrl(Url imageUrl)
        {
            this.ProductImage = imageUrl;
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<ProductFollow>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            ProductFollow instance = obj as ProductFollow;

            bool isIdSame = this.Id == instance.Id;
            bool isProductIdSame = this.ProductId == instance.SellerId;
            bool isSellerIdSame = this.SellerId == instance.SellerId;
            bool isActiveSame = this.IsActive == instance.IsActive;
            bool isUrlSame = this.ProductPage == instance.ProductPage;

            return isIdSame && isProductIdSame && isSellerIdSame && isActiveSame && isUrlSame;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 1579;

                hash = hash * 12413 + this.Id.GetHashCode();
                hash = hash * 12413 + this.ProductId.GetHashCode();
                hash = hash * 12413 + this.SellerId.GetHashCode();

                return hash;
            }
        }
    }
}
