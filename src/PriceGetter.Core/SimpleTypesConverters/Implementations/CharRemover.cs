using PriceGetter.Core.SimpleTypesConverters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceGetter.Core.SimpleTypesConverters.Implementations
{
    public class CharRemover : ICharRemover
    {
        public string Remove(string text, char character)
        {
            while (text.Any(x => x == character))
            {
                int index = text.IndexOf(character);
                text = text.Remove(index, 1);
            }

            return text;
        }
    }
}
