using PriceGetter.Core.Enums;
using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces
{
    public interface IPriceProviderFactory
    {
        IPriceProvider GetProvider(Product product);
    }
}
