using System;
using CarManager.Models;

namespace CarManager.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DeliveryRoute> Routes { get; }

        IRepository<Operator> Operators { get; }

        void Save();
    }
}
