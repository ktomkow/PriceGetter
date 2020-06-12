using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Html : ValueObjectBase
    {
        public string RawContent { get; }

        public Html(string rawContent)
        {
            this.RawContent = rawContent ?? throw new ArgumentNullException(nameof(rawContent));
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<Html>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            Html instance = obj as Html;

            return this.RawContent == instance.RawContent;
        }

        public override int GetHashCode()
        {
            return this.RawContent.GetHashCode();
        }
    }
}
