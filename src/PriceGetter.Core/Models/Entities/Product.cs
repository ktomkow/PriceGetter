using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceGetter.Core.Models.Entities
{
    public class Product : EntityBase
    {
        private readonly HashSet<Price> prices;

        public Name Name { get; protected set; }

        public bool MonitoringActive { get; protected set; }

        public Url ProductPage { get; protected set; }

        public Url ProductImage { get; protected set; }

        public IEnumerable<Price> Prices =>
            this.prices.OrderByDescending(x => x.At).ToList();

        protected Product() : base() 
        {
            this.prices = new HashSet<Price>();
            this.ProductImage = Url.FromString(string.Empty);

            this.MonitoringActive = true;
        }

        public Product(Name name, Url productPage) : this()
        {
            this.Rename(name); 
            this.ChangeProductPage(productPage);
        }

        public void Rename(Name name)
        {
            this.Name = name;
        }

        public void ChangeProductPage(Url url)
        {
            this.ProductPage = url;
        }

        public void ChangeImageUrl(Url url)
        {
            this.ProductImage = url;
        }

        public void AddPrice(Money amount)
        {
            Price price = new Price(amount, this);
            this.prices.Add(price);
        }

        public Price GetLastPrice()
        {
            return this.Prices.First();
        }

        public void ActivateMonitoring()
        {
            this.MonitoringActive = true;
        }

       public void DeactivateMonitoring()
        {
            this.MonitoringActive = false;
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<Product>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            Product instance = obj as Product;

            bool isNameSame = this.Name == instance.Name;
            bool isProductPageSame = this.ProductPage == instance.ProductPage;

            return isNameSame && isProductPageSame;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 8627;

                hash = hash * 12413 + this.Name.GetHashCode();
                hash = hash * 12413 + this.ProductPage.GetHashCode();

                return hash;
            }
        }
    }
}
