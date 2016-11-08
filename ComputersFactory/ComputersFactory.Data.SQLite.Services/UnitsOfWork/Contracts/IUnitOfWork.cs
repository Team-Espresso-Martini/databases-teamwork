using System;

namespace ComputersFactory.Data.SQLite.Services.UnitsOfWork.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
