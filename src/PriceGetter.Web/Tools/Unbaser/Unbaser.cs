using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Web.Tools.Unbaser
{
    public class Unbaser : IUnbaser
    {
        /// <inheritdoc/>
        public string Unbase(string text)
        {
            text = text.Replace('_', '/');
            text = text.Replace('-', '+');
            byte[] byteArray = Convert.FromBase64String(text);
            string unbasedString = Encoding.UTF8.GetString(byteArray);

            return unbasedString;
        }
    }
}
