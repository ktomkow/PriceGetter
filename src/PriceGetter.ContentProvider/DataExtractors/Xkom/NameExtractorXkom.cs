using PriceGetter.Core.Exceptions.NotExtractable;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors.Xkom;
using PriceGetter.Core.Models.ValueObjects;
using System;

namespace PriceGetter.ContentProvider.DataExtractors.Xkom
{
    public class NameExtractorXkom : IXkomNameExtractor
    {
        private readonly ICssContentExtractor cssContentExtractor;

        public NameExtractorXkom(ICssContentExtractor cssContentExtractor)
        {
            this.cssContentExtractor = cssContentExtractor;
        }

        public Name Extract(Html html)
        {
            try
            {
                CssClass cssClass = new CssClass("sc-1bker4h-4 driGYx");

                string rawName = this.cssContentExtractor.Extract(html, cssClass);

                Name name = new Name(rawName);

                return name;

            }
            catch (Exception)
            {
                throw new NotExtractableException(nameof(NameExtractorXkom));
            }
        }
    }
}
