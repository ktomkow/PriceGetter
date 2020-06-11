using PriceGetter.Core.SimpleTypesConverters.Implementations;
using PriceGetter.Core.SimpleTypesConverters.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.SimpleTypesConverters.Extensions
{
    public static class StringExtensions
    {
        private static readonly IStringDecimalConverter stringDecimalConverter = new StringDecimalConverter();
        private static readonly ICharRemover charRemover = new CharRemover();

        public static decimal ToDecimal(this string text)
        {
            decimal result = stringDecimalConverter.ToDecimal(text);
            return result;
        }

        public static string RemoveChar(this string text, char characterToRemove)
        {
            string result = charRemover.Remove(text, characterToRemove);
            return result;
        }
    }
}
