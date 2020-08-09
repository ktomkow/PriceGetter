using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Contracts.Products
{
    public class CreateProductFollowCommand
    {
        public Guid ProductId { get; set; }
        public string ProductUrl { get; set; }
    }
}
