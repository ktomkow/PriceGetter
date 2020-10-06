using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.Entities;
using PriceGetter.PersistenceEntityFramework.TypesConfigurations;

namespace PriceGetter.PersistenceEntityFramework
{
    public class PriceGetterDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public PriceGetterDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=PriceGetter;Trusted_Connection=True;")
                .UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Price>().ToTable("Prices");
            modelBuilder.Entity<Price>().HasKey(x => x.Id);
            modelBuilder.Entity<Price>().Property(x => x.At);
            modelBuilder.Entity<Price>().OwnsOne(x => x.Amount)
                .Property(x => x.ValuAsDecimal)
                .HasColumnName("Amount")
                .HasColumnType("decimal(19,4");

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
