using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.PersistenceEntityFramework.TypesConfigurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Prices);

            builder.Property(x => x.ProductPage)
                .HasConversion(
                x => x.ToString(),
                x => Url.FromString(x))
                .HasColumnName("PageUrl");

            builder.Property(x => x.ProductImage)
                .HasConversion(
                x => x.ToString(),
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
