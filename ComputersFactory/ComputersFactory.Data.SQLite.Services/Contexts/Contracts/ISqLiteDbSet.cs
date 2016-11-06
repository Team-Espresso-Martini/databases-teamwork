using System.Collections.Generic;

namespace ComputersFactory.Data.SQLite.Services.Contexts.Contracts
{
    public interface ISqLiteDbSet<TEntity> where TEntity : class
    {
        void CreateTable();

        void Add(TEntity entity);

        IEnumerable<TEntity> All();

        TEntity Find(int id);
    }
}
