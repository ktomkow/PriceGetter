using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.DataProviders.Xkom
{
    public class XKomNameProvider : INameProvider
    {
        public Task<Name> GetName(Url productPage)
        {
            throw new NotImplementedException();
        }
    }
}
