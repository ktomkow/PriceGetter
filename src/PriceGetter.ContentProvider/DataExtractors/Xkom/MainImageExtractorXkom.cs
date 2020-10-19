using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Core.SimpleTypesConverters.Extensions;
using System.Text.RegularExpressions;

namespace PriceGetter.ContentProvider.DataExtractors.Xkom
{
    public class MainImageExtractorXkom : IMainImageExtractor
    {
        public MainImageExtractorXkom()
        {
        }

        public Url Extract(Html html)
        {
            string elementWithImage = this.ExtractElementWithImage(html);
            Url url = this.ExtractImageUrlFromElement(elementWithImage);

            return url;
        }

        private string ExtractElementWithImage(Html html)
        {
            string pattern = "<span class=\"sc-1tblmgq-0 sc-1y93ua6-0 lodfKm sc-1tblmgq-2 bIcxIH\"><img src=.+ class=\"sc-1tblmgq-1 bxjRuC\"";
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
            
            Url url = new Url(rawUrl);

            return url;
        }
    }
}
