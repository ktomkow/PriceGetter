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
        public DataProvider Provider { get; protected set; } // todo: czy to ta powinno być zrealizowane? jak określić do którego sprzedawcy używany jest który obiekt dostarczający ceny?

        public Seller(Name name, Guid guid) : base(guid)
        {
            this.Rename(name);
        }

        public Seller(Name name)
        {
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
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
