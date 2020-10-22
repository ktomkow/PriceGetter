using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.DataExtractors
{
    public interface ICssPriceExtractor : IExtractor
    {
        Money Extract(Html html, CssClass cssClass);
    }   
}
