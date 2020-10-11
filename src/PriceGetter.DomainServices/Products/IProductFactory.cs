using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.DomainServices.Products
{
    public interface IProductFactory
    {
        Product Create(PreProduct preProduct);
    }
}
