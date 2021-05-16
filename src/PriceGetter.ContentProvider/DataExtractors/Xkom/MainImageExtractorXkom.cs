using PriceGetter.Core.Exceptions.NotExtractable;
using PriceGetter.Core.Interfaces.DataExtractors.Xkom;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Core.SimpleTypesConverters.Extensions;
using System;
using System.Text.RegularExpressions;

namespace PriceGetter.ContentProvider.DataExtractors.Xkom
{
    public class MainImageExtractorXkom : IXkomImageUrlExtractor
    {
        public Url Extract(Html html)
        {
            try
            {
                string elementWithImage = this.ExtractElementWithImage(html);
                Url url = this.ExtractImageUrlFromElement(elementWithImage);

                return url;
            }
            catch (Exception)
            {
                throw new NotExtractableException(nameof(MainImageExtractorXkom));
            }
        }

        private string ExtractElementWithImage(Html html)
        {
            string pattern = "<span class=\"sc-1tblmgq-0 jiiyfe-2 ldEQXA sc-1tblmgq-3 fHoITM\"><img src=\"[^>]*\" class=\"sc-1tblmgq-2 icFHil\"\\/>";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(html.RawContent);
            string dirtyResult = match.Value;

            return dirtyResult;
        }

        private Url ExtractImageUrlFromElement(string html)
        {
            string pattern = "http[s*]:.+\" alt";
            Regex regex = new Regex(pattern);

            Match match = regex.Match(html);

            string dirtyResult = match.Value;

            string rawUrl = dirtyResult.Substring(0, dirtyResult.Length - 3);
            rawUrl = rawUrl.RemoveChar('"');
            rawUrl = rawUrl.Trim();

            Url url = Url.FromString(rawUrl);

            return url;
        }
    }
}
