using System.Collections.Generic;

namespace ComputersFactory.Data.SQLite.Services.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> All();

        TEntity Find(int id);
    }
}
