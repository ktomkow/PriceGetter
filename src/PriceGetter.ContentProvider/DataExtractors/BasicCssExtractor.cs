using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Interfaces.DataExtractors;
using PriceGetter.Core.Models.ValueObjects;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PriceGetter.ContentProvider.DataExtractors
{
    public class BasicCssExtractor : ICssContentExtractor
    {
        private readonly IDictionary<string, string> toSpecialMarks;
        private readonly IDictionary<string, string> toNormalChars;

        public BasicCssExtractor()
        {
            this.toSpecialMarks = new Dictionary<string, string>();
            this.toNormalChars = new Dictionary<string, string>();

            this.toSpecialMarks.Add("&quot;", "QUOTATION_MARK");
            this.toSpecialMarks.Add("(", "LEFT_BRACKET");
            this.toSpecialMarks.Add(")", "RIGHT_BRACKET");

            this.toNormalChars.Add("QUOTATION_MARK", "\"");
            this.toNormalChars.Add("LEFT_BRACKET", "(");
            this.toNormalChars.Add("RIGHT_BRACKET", ")");
        }


        public string Extract(Html html, CssClass cssClass)
        {
            if(html == null || cssClass == null)
            {
                return string.Empty;
            }

            Regex outerRegex = new Regex($"class\\s*=\\s*\"{cssClass.Value}\"\\s*>(\\s*\\w+[+-=/]*\\s*)*<");

            Regex innerRegex = new Regex(">.*<");

            Match outerMatch = outerRegex.Match(this.MarkSpecialChars(html.RawContent));

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

            return this.UnMarkSpecialChars(result);
        }

        private string MarkSpecialChars(string text)
        {
            foreach (KeyValuePair<string, string> item in this.toSpecialMarks)
            {
                text = text.Replace(item.Key, item.Value);
            }

            return text;
        }

        private string UnMarkSpecialChars(string text)
        {
            foreach (KeyValuePair<string, string> item in this.toNormalChars)
            {
                text = text.Replace(item.Key, item.Value);
            }

            return text;
        }
    }
}
