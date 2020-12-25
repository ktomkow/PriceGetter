using System;
using System.Text;

namespace PriceGetter.Web.Tools.Unbaser
{
    /// <inheritdoc/>
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
