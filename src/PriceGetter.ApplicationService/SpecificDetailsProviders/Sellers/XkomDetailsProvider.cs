using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.ContentProvider.ImagesUrlExtractors;
using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.ContentProvider.NameExtractors;
using PriceGetter.ContentProvider.PriceExtractors;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Enums;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.WebClients;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<SellerSpecificDetailsDto> GetAsync(Url url)
        {
            Html html = await this.htmlGetter.GetAsync(url);

            Money currentPrice = this.priceExtractor.Extract(html);
            Name productName = this.nameExtractor.Extract(html);
            Url imageUrl = this.imageExtractor.Extract(html);

            var result = new SellerSpecificDetailsDto()
            {
                Name = productName.Value,
                CurrentPrice = currentPrice.Value,
                ProductPage = url.Value,
                Seller = SellerSystem.xkom.ToString(),
                ImageUrl = imageUrl.Value
            };

            return result;
        }
    }
}
