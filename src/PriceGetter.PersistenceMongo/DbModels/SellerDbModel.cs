using PriceGetter.Core.Entities;
using PriceGetter.Core.Enums;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceMongo.DbModels
{
    public class SellerDbModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Homepage { get; set; }
        public string SellerSystem { get; set; }


        public SellerDbModel(Seller seller)
        {
            this.Id = seller.Id.ToString();
            this.Name = seller.Name.Value;
            this.Homepage = seller.HomePage.Value;
            this.SellerSystem = seller.SellerSystem.ToString();
        }

        public Seller ToSeller()
        {
            Guid id = new Guid(this.Id);
            Name name = new Name(this.Name);
            Url url = new Url(this.Homepage);
            SellerSystem sellerSystem = Core.Enums.SellerSystem.xkom;
            Seller seller = new Seller(name, sellerSystem, id);
            seller.UpdateHomePage(url);

            return seller;
        }
    }
}
