﻿using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.Factories.DataProviders
{
    public interface IPriceProviderFactory
    {
        IPriceProvider GetProvider(Url productPage);

        //IPriceProvider GetProvider(Product produt);
    }
}
