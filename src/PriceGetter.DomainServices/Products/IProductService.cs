using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.DomainServices.Products
{
    public interface IProductService
    {
        IEnumerable<Product> Get();

        IEnumerable<Product> GetActive();
    }
}
