using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Html
    {
        public string RawContent { get; }

        public Html(string rawContent)
        {
            this.RawContent = rawContent ?? throw new ArgumentNullException(nameof(rawContent));
        }
    }
}
