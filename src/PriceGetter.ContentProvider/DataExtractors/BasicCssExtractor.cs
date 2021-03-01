using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Models.ValueObjects;
using System.Text.RegularExpressions;

namespace PriceGetter.ContentProvider.DataExtractors
{
    public class BasicCssExtractor : ICssContentExtractor
    {
        public string Extract(Html html, CssClass cssClass)
        {
            if(html == null || cssClass == null)
            {
                return string.Empty;
            }

            Regex outerRegex = new Regex($"class\\s*=\\s*\"{cssClass.Value}\"\\s*>(\\s*\\w+[+-=/]*\\s*)*<");

            Regex innerRegex = new Regex(">.*<");

            Match outerMatch = outerRegex.Match(html.RawContent.Replace("&quot;", "special_qutoation"));

            if(outerMatch.Success == false)
            {
                return string.Empty;
            }

            Match innerMatch = innerRegex.Match(outerMatch.Groups[0].Value);

            if (innerMatch.Success == false)
            {
                return string.Empty;
            }

            string result = innerMatch.Value.Substring(1, innerMatch.Value.Length -2);

            return result.Replace("special_qutoation", "\"");
        }
    }
}
