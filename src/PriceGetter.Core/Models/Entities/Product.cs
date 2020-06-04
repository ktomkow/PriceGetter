using PriceGetter.Core.BaseClasses.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; protected set; }

        protected Product() : base() { }

        public Product(Guid guid) : base(guid) { }


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
