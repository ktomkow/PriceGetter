using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Contracts.Products
{
    public class PriceDto
    {
        public decimal Price { get; set; }
        public DateTime At { get; set; }
    }
}
