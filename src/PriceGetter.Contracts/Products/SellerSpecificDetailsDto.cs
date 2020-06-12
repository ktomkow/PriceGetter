using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Contracts.Products
{
    public class SellerSpecificDetailsDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ProductPage { get; set; }
        public string Seller { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
