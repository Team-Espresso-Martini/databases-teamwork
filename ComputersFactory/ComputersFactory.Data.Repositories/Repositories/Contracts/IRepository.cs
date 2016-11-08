using System.Collections.Generic;

namespace ComputersFactory.Data.Repositories.Repositories.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
    }
}
