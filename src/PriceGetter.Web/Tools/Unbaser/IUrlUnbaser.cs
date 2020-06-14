using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Tools.Unbaser
{
    public interface IUrlUnbaser
    {
        Url Unbase(string url);
    }
}
