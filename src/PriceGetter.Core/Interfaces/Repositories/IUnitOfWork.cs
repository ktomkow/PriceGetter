﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();

        IProductsRepository ProductRepository { get; }
    }
}
