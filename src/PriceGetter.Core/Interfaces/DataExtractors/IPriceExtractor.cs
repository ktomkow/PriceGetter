using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.DataExtractors
{
    public interface IPriceExtractor : IExtractor
    {
        Money Extract(Html html);
    }
}
