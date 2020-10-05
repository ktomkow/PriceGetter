using Microsoft.EntityFrameworkCore;
using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.Entities;

namespace PriceGetter.PersistenceEntityFramework
{
    public class PriceGetterDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PriceGetterDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PriceGetter;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().HasMany(x => x.Prices);
            modelBuilder.Entity<Product>().OwnsOne(x => x.Name).Property(x => x.ValueAsString).HasColumnName("Name");
            modelBuilder.Entity<Product>().OwnsOne(x => x.ProductPage).Property(x => x.ValueAsString).HasColumnName("PageUrl");
            modelBuilder.Entity<Product>().OwnsOne(x => x.ProductImage).Property(x => x.ValueAsString).HasColumnName("ImageUrl");

            modelBuilder.Entity<Price>().ToTable("Prices");
            modelBuilder.Entity<Price>().HasKey(x => x.Id);
            modelBuilder.Entity<Price>().Property(x => x.At);
            modelBuilder.Entity<Price>().OwnsOne(x => x.Amount).Property(x => x.ValuAsDecimal).HasColumnName("Amount");
        }
    }
}
