using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceGetter.Core.Models.Entities
{
    public class Product : EntityBase
    {
        private readonly HashSet<Price> prices;

        public Name Name { get; protected set; }

        public IEnumerable<Price> PriceHistory =>
            this.prices.OrderByDescending(x => x.At).ToList();

        protected Product() : base() 
        {
            this.prices = new HashSet<Price>();
        }

        public Product(Name name, Guid guid) : base(guid)
        {
            this.Rename(name);
            this.prices = new HashSet<Price>();
        }

        public Product(Name name) : base()
        {
            this.Rename(name);
            this.prices = new HashSet<Price>();
        }

        public void Rename(Name name)
        {
            this.Name = name;
        }

        public void AddPrice(Money price, Guid sellerId)
        {
            Price timedPrice = new Price(price, this.Id, sellerId, DateTime.UtcNow);
            this.prices.Add(timedPrice);
        }

        public void AddPrice(Money price, Guid sellerId, DateTime dateTime)
        {
            Price timedPrice = new Price(price, this.Id, sellerId, dateTime);
            this.prices.Add(timedPrice);
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
