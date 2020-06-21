using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.PriceProviders
{
    public interface IPriceProvider
    {
        Task<Money> Get(ProductFollow productFollow);
    }
}
