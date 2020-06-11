using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces
{
    public interface ICssContentExtractor : IExtractor
    {
        string Extract(Html html, string cssClass);
    }
}
