using PriceGetter.Core.BaseClasses;
using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.Entities.SellerSpecificData
{
    public class XkomProduct : SellerSpecificDataBase
    {
        public Url ProductPage { get; protected set; }

        public XkomProduct(Guid productId) : base(productId) { }

        public XkomProduct(Guid productId, Url productPage) : base(productId)
        {
            this.ProductPage = productPage;
        }

        public void ChangeProductPage(Url newUrl)
        {
            this.ProductPage = newUrl;
        }

        public override void StartFollowing()
        {
            if(this.ProductPage is null)
            {
                throw new InvalidOperationException("Product cannot be followed because it does not contain any information source");
            }

            this.IsActive = true;
        }

        public override void StopFollowing()
        {
            if (this.ProductPage != null)
            {
                this.IsActive = false;
            }
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
