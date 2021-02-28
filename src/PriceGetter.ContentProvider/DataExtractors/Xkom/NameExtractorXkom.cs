using PriceGetter.Core.Exceptions.NotExtractable;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Interfaces.DataExtractors.Xkom;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;

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
            List<CssClass> possibleClasses = new List<CssClass>();
            possibleClasses.Add(new CssClass("sc-1bker4h-4 driGYx"));
            possibleClasses.Add(new CssClass("sc-1bker4h-4 fiaogA"));

            return this.Extract(html, possibleClasses);
        }

        private Name Extract(Html html, IEnumerable<CssClass> possibleClassess)
        {
            foreach (var cssClass in possibleClassess)
            {
                try
                {
                    Name name = this.Extract(html, cssClass);
                    return name;
                }
                catch (NotExtractableException)
                {
                    continue;
                }
            }

            throw new NotExtractableException(nameof(NameExtractorXkom));
        }

        private Name Extract(Html html, CssClass cssClass)
        {
            try
            {
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
