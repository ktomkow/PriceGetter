using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();

        ISellersRepository SellersRepository { get; }
        IProductRepository ProductRepository { get; }
        IFollowedProductRepository FollowedProductRepository { get; }
    }
}
