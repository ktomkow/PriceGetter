using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class CssClass : ValueObjectBase
    {
        public string Value { get; }

        public CssClass(string cssClass)
        {
            if(string.IsNullOrWhiteSpace(cssClass))
            {
                throw new ArgumentException("Css class cannot be empty");
            }   
            
            this.Value = cssClass;
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<CssClass>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            CssClass instance = obj as CssClass;

            return this.Value == instance.Value;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
