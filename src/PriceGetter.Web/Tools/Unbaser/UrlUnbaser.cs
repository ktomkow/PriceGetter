using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Web.Tools.Unbaser
{
    public class UrlUnbaser : IUrlUnbaser
    {
        public Url Unbase(string urlInBase64)
        {
            urlInBase64 = urlInBase64.Replace('_', '/');
            urlInBase64 = urlInBase64.Replace('-', '+');
            byte[] byteArray = Convert.FromBase64String(urlInBase64);
            urlInBase64 = Encoding.UTF8.GetString(byteArray);

            Url url = new Url(urlInBase64);

            return url;
        }
    }
}
