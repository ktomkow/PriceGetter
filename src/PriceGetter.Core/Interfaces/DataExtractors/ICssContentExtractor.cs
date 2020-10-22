using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.DataExtractors
{
    public interface ICssContentExtractor : IExtractor
    {
        string Extract(Html html, CssClass cssClass);
    }
}
