using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.ContentProvider.DataExtractors.Xkom;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;

using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders.Sellers
{
    public class XkomDetailsProvider : ISpecificDetailsProvider
    {
        private readonly IHtmlContentGetter htmlGetter;
        private readonly PriceExtractorXkom priceExtractor;
        private readonly NameExtractorXkom nameExtractor;
        private readonly MainImageExtractorXkom imageExtractor;

        public XkomDetailsProvider(
            IHtmlContentGetter htmlGetter
            ,PriceExtractorXkom priceExtractor
            ,NameExtractorXkom nameExtractor
            ,MainImageExtractorXkom imageExtractor)
        {
            this.htmlGetter = htmlGetter;
            this.priceExtractor = priceExtractor;
            this.nameExtractor = nameExtractor;
            this.imageExtractor = imageExtractor;
        }

        public async Task<PreProductDto> GetAsync(Url url)
        {
            Html html = await this.htmlGetter.GetAsync(url);

            Money currentPrice = this.priceExtractor.Extract(html);
            Name productName = this.nameExtractor.Extract(html);
            Url imageUrl = this.imageExtractor.Extract(html);

            var result = new PreProductDto()
            {
                Name = productName.ToString(),
                Price = currentPrice.ValueAsDecimal,
                ProductPage = url.ToString(),
                ImageUrl = imageUrl.ToString()
            };

            return result;
        }
    }
}
