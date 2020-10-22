using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.Core.Interfaces.DataExtractors
{
    public interface IMainImageExtractor
    {
        Url Extract(Html html);
    }
}
