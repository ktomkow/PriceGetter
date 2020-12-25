using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Web.Tools.Unbaser
{
    /// <summary>
    /// Converts url encoded using base 64 to standard string
    /// </summary>
    public interface IUrlUnbaser
    {
        /// <summary>
        /// Converts url encoded using base 64 to standard string
        /// </summary>
        /// <param name="url">Url address encoded using base 64</param>
        /// <returns>Human-readable string</returns>
        Url Unbase(string url);
    }
}
