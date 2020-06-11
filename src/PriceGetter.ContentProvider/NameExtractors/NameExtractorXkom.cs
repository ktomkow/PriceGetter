using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.ContentProvider.NameExtractors
{
    public class NameExtractorXkom : INameExtractor
    {
        private readonly ICssContentExtractor cssContentExtractor;

        public NameExtractorXkom(ICssContentExtractor cssContentExtractor)
        {
            this.cssContentExtractor = cssContentExtractor;
        }

        public Name Extract(Html html)
        {
            CssClass cssClass = new CssClass("s");

            string rawName = this.cssContentExtractor.Extract(html, cssClass);

            Name name = new Name(rawName);

            return name;
        }
    }
}
