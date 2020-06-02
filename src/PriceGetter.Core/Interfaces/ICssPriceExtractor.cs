using PriceGetter.Core.Models;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces
{
    public interface ICssPriceExtractor
    {
        Price Extract(string html, string cssClass);
    }   
}
