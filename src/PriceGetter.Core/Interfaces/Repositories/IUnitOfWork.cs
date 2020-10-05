using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        void Commit();

        IProductsRepository ProductRepository { get; }
    }
}
