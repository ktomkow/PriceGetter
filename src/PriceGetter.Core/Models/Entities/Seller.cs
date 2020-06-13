using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Enums;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Entities
{
    public class Seller : EntityBase
    {
        public Name Name { get; protected set; }
        public Url HomePage { get; protected set; }
        public SellerSystem SellerSystem { get; } 

        protected Seller() : base() { }

        public Seller(Name name, SellerSystem sellerSystem, Guid guid) : base(guid)
        {
            this.SellerSystem = sellerSystem;
            this.Rename(name);
        }

        public Seller(Name name, SellerSystem sellerSystem)
        {
            this.SellerSystem = sellerSystem;
            this.Rename(name);
        }

        public void Rename(Name name)
        {
            this.Name = name;
        }

        public void UpdateHomePage(Url url)
        {
            this.HomePage = url;
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<Seller>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            Seller instance = obj as Seller;

            bool isNameSame = this.Name == instance.Name;
            bool isIdSame = this.Id == instance.Id;
            bool isSameHomePage = this.HomePage == instance.HomePage;
            bool isSameSystem = this.SellerSystem == instance.SellerSystem;

            return isNameSame && isIdSame && isSameHomePage && isSameSystem;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 14519;

                hash = hash * 13267 + this.Id.GetHashCode();
                hash = hash * 13267 + this.Name.GetHashCode();
                hash = hash * 13267 + this.HomePage.GetHashCode();
                hash = hash * 13267 + this.SellerSystem.GetHashCode();

                return hash;
            }
        }
    }
}
