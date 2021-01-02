using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PriceGetter.Core.BaseClasses.Entities;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Infrastructure.Settings;
using PriceGetter.PersistenceEntityFramework.TypesConfigurations;

namespace PriceGetter.PersistenceEntityFramework
{
    public class PriceGetterDbContext : DbContext
    {
        private readonly SqlSettings settings;

        public DbSet<Product> Products { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public PriceGetterDbContext()
        {

        }

        public PriceGetterDbContext(SqlSettings sqlSettings)
        {
            this.settings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(this.settings is null)
            {
                optionsBuilder
                .UseSqlServer(@"Server=192.168.0.133,6900;Database=PriceGetter;User Id=app;Password=pgApplication123!;")
                .UseLoggerFactory(MyLoggerFactory);
            }
            else
            {
                optionsBuilder
                .UseSqlServer(this.settings.ConnectionString)
                .UseLoggerFactory(MyLoggerFactory);
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();

            modelBuilder.Entity<Price>().ToTable("Prices");
            modelBuilder.Entity<Price>().HasKey(x => x.Id);
            modelBuilder.Entity<Price>().Property(x => x.At);
            modelBuilder.Entity<Price>().OwnsOne(x => x.Amount)
                .Property(x => x.ValueAsDecimal)
                .HasColumnName("Amount")
                .HasColumnType("decimal(19,4");

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
