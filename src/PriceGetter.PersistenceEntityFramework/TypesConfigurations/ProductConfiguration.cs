using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.PersistenceEntityFramework.ExtensionMethods;

namespace PriceGetter.PersistenceEntityFramework.TypesConfigurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Prices).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ProductPage)
                .HasConversion(
                x => x.ToStringNullIfEmpty(),
                x => Url.FromString(x))
                .HasColumnName("PageUrl");

            builder.Property(x => x.ProductImage)
                .HasConversion(
                x => x.ToStringNullIfEmpty(),
                x => Url.FromString(x))
                .HasColumnName("ImageUrl");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion(
                x => x.ToString(),
                x => new Name(x));
        }
    }
}
