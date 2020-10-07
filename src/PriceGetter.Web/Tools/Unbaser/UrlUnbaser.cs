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
        private readonly IUnbaser unbaser;

        public UrlUnbaser(IUnbaser unbaser)
        {
            this.unbaser = unbaser;
        }

        public Url Unbase(string urlInBase64)
        {
            string unbased = this.unbaser.Unbase(urlInBase64);

            Url url = Url.FromString(unbased);

            return url;
        }
    }
}
