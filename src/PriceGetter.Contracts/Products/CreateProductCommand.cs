﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Contracts.Products
{
    public class CreateProductCommand
    {
        public string Name { get; set; }

        public string ProductPage { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
