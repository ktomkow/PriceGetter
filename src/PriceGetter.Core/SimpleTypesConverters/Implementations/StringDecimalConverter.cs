using PriceGetter.Core.SimpleTypesConverters.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PriceGetter.Core.SimpleTypesConverters.Implementations
{
    public class StringDecimalConverter : IStringDecimalConverter
    {
        public decimal ToDecimal(string value)
        {
            int dotsCount = value.Count(x => x == '.');
            int commaCount = value.Count(x => x == ',');

            if (dotsCount + commaCount <= 1)
            {
                return this.ToDecimalOnlyDigitsSeparator(value);
            }

            return this.ToDecimalHasThousandsSeparator(value);
        }

        private decimal ToDecimalHasThousandsSeparator(string value)
        {
            int dotsCount = value.Count(x => x == '.');
            int commaCount = value.Count(x => x == ',');

            if(dotsCount > commaCount)
            {
                value = this.RemoveChar(value, '.');
            }
            else if(dotsCount < commaCount)
            {
                value = this.RemoveChar(value, ',');
            }
            else if(dotsCount == commaCount)
            {
                int lastDotIndex = value.LastIndexOf('.');
                int lastCommaIndex = value.LastIndexOf(',');

                if(dotsCount == -1 || commaCount == -1) // text contains only dots or comma thousand separators (at least two)
                {
                    throw new NotImplementedException();
                }
                else if(lastDotIndex > lastCommaIndex)
                {
                    value = this.RemoveChar(value, ',');
                }
                else if(lastDotIndex < lastCommaIndex)
                {
                    value = this.RemoveChar(value, '.');
                }
            }

            return this.ToDecimalOnlyDigitsSeparator(value);
        }

        private decimal ToDecimalOnlyDigitsSeparator(string value)
        {
            try
            {
                decimal result = decimal.Parse(value, NumberStyles.Any, new CultureInfo("pl"));
                return result;
            }
            catch (FormatException)
            {
                value = value.Replace('.', ',');
                decimal result = Convert.ToDecimal(value);
                return result;
            }
        }

        private string RemoveChar(string text, char character)
        {
            while(text.Any(x => x == character))
            {
                int index = text.IndexOf(character);
                text = text.Remove(index, 1);
            }

            return text;
        }
    }
}
