using PriceGetter.Core.Entities;
using PriceGetter.Core.Enums;
using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.ApplicationServices.PriceProviders
{
    public interface IPriceProviderFactory
    {
        IPriceProvider GetProvider(Seller seller);
    }
}
