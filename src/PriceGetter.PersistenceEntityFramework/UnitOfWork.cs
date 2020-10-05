using PriceGetter.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.PersistenceEntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PriceGetterDbContext db;

        public IProductsRepository ProductRepository { get; }

        public UnitOfWork(PriceGetterDbContext db, IProductsRepository productsRepository)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.ProductRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public void Commit()
        {
            this.db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await this.db.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
