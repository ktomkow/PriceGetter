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
        private readonly HashSet<TimedPrice> prices;

        public Name Name { get; protected set; }

        public IEnumerable<TimedPrice> PriceHistory =>
            this.prices.OrderByDescending(x => x.At).ToList();

        protected Product() : base() { }

        public Product(Name name, Guid guid) : base(guid)
        {
            this.Rename(name);
        }

        public Product(Name name) : base()
        {
            this.Rename(name);
        }

        public void Rename(Name name)
        {
            this.Name = name;
        }

        public void AddPrice(Money price)
        {
            TimedPrice timedPrice = new TimedPrice(price);
            this.AddPrice(timedPrice);
        }

        public void AddPrice(TimedPrice price)
        {
            this.prices.Add(price);
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
