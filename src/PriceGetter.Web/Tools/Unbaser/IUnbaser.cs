namespace PriceGetter.Web.Tools.Unbaser
{
    /// <summary>
    /// Converts text encoded using base 64 to standard string
    /// </summary>
    public interface IUnbaser
    {
        /// <summary>
        /// Turns string encoded as base64 text to readable string
        /// </summary>
        /// <param name="text">String encoded as base64</param>
        /// <returns>Human-readable string</returns>
        string Unbase(string text);
    }
}
