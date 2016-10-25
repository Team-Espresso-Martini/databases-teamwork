using System;

using ComputersFactory.Data.Repositories.Repositories.Contracts;

namespace ComputersFactory.Data.Repositories.Repositories
{
    public class GenericRepository<TEntity> 
        : IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
