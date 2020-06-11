using PriceGetter.Core.BaseClasses.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.BaseClasses.Entities
{
    public abstract class SellerSpecificDataBase : EntityBase
    {
        public Guid ProductId => this.Id; 
        public bool IsActive { get; protected set; }
        // prop cron z propami active/inactive?

        public SellerSpecificDataBase(Guid productId) : base(productId)
        {
            this.IsActive = false;
        }

        public abstract void StartFollowing();
        public abstract void StopFollowing();

    }
}
