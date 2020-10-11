using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Contracts.Products
{
    public class CreateProductCommand
    {
        public string Name { get; set; }

        public string Page { get; set; }

        public string Image { get; set; }
    }
}
