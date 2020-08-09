using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Tools.Unbaser
{
    public interface IUnbaser
    {
        /// <summary>
        /// Turns string encoded as base64 text to readable string
        /// </summary>
        /// <param name="text">String encoded as base64</param>
        /// <returns></returns>
        string Unbase(string text);
    }
}
