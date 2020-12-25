using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Web.Tools.Unbaser
{
    /// <inheritdoc/>
    public class UrlUnbaser : IUrlUnbaser
    {
        private readonly IUnbaser unbaser;

        /// <summary>
        /// Public constructor using dependency injection
        /// </summary>
        /// <param name="unbaser">Implementation of IUnbaser class</param>
        public UrlUnbaser(IUnbaser unbaser)
        {
            this.unbaser = unbaser;
        }

        /// <inheritdoc/>
        public Url Unbase(string urlInBase64)
        {
            string unbased = this.unbaser.Unbase(urlInBase64);

            Url url = Url.FromString(unbased);

            return url;
        }
    }
}
