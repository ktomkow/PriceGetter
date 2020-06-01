using PriceGetter.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class TimedPrice : TimedPriceBase
    {
        protected TimedPrice() : base(){ }

        public TimedPrice(PriceBase price) : base(price, DateTime.Now) { }

        public TimedPrice(PriceBase price, DateTime at) : base(price, at) { }
    }
}
