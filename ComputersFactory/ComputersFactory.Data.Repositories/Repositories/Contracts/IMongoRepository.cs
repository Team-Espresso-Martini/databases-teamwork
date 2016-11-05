using System.Collections.Generic;

namespace ComputersFactory.Data.Repositories.Repositories.Contracts
{
    public interface IMongoRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void AddMany(IEnumerable<TEntity> entities);
    }
}
