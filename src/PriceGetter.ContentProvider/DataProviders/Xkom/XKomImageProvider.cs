using PriceGetter.Core.Interfaces.DataProviders;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.DataProviders.Xkom
{
    public class XKomImageProvider : IImageUrlProvider
    {
        public Task<Url> GetImageUrl(Url productPage)
        {
            throw new NotImplementedException();
        }
    }
}
