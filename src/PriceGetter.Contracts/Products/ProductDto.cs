using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Contracts.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ProductPage { get; set; }

        public string ImageUrl { get; set; }


        public IEnumerable<PriceDto> Prices { get; set; }   
    }
}
