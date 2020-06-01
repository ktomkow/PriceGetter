using PriceGetter.Core.Models;
using PriceGetter.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces
{
    public interface ICssPriceExtractor
    {
        PriceBase Extract(string html, string cssClass);
    }   
}
