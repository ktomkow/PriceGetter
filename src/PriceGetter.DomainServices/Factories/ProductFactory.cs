using PriceGetter.Core.Interfaces.Factories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.DomainServices.Factories
{
    public class ProductFactory : IProductFactory
    {
        public Product Create(PreProduct preProduct)
        {
            Product product = new Product(preProduct.Name, preProduct.ProductPage);

            product.ChangeImageUrl(preProduct.ImageUrl);
            product.AddPrice(preProduct.Price);

            return product;
        }
    }
}
