using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces
{
    public interface INameExtractor : IExtractor
    {
        Name Extract(Html html);
    }
}
