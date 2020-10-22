using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.DataExtractors
{
    public interface INameExtractor : IExtractor
    {
        Name Extract(Html html);
    }
}
